using Microsoft.Win32;
using MindFusion.Charting.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrabalhoSO.Algoritmos;

namespace TrabalhoSO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Arquivo;
        public List<int> numero;
        public List<string> operacao;
        public int Q1;
        public int Q2;
        public int ZerarBitR;

        public ObservableCollection<LineSeries> mydata = new ObservableCollection<LineSeries>();

        public MainWindow()
        {
            InitializeComponent();

            numero = new List<int>();
            operacao = new List<string>();

            MyChart.ItemsSource = mydata;
            

        }

        private async void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {

            Q1 = Int32.Parse(Q1text.Text);
            Q2 = Int32.Parse(Q2text.Text);
            ZerarBitR = Int32.Parse(ZerarBitRtext.Text);


            OpenFileDialog openFileDialog = new OpenFileDialog
            {

                //define as propriedades do controle 
                //OpenFileDialog
                Multiselect = false,
                Title = "Selecionar Arquivo",
                InitialDirectory = @"C:\",
                //filtra para exibir somente arquivos de imagens
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                CheckFileExists = true,
                CheckPathExists = true,
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };


            if (openFileDialog.ShowDialog() == true)
            {
                // Le o arquivo selecionado
                Arquivo = File.ReadAllText(openFileDialog.FileName);

                //reparte o arquivo em duas partes, numero e operação  
                Char delimiter = '-';
                String[] substrings = Arquivo.Split(delimiter);
                foreach (string item in substrings)
                {
                    if (item != "")
                    {
                        int value1 = Int32.Parse(item.Substring(0, (item.Length - 1)));
                        string value2 = item.Substring(1, 1);
                        numero.Add(value1);
                        operacao.Add(value2);
                    }
                }
            }

            //começa tasks'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            FIFO Fifo = new FIFO(Q1, Q2, numero);
            SC Sc     = new SC  (Q1, Q2, ZerarBitR, numero, operacao);
            LRU Lru   = new LRU (Q1, Q2, numero);
            NRU Nru   = new NRU (Q1, Q2, ZerarBitR, numero, operacao);
            BEST Best = new BEST(Q1, Q2, numero);

            List<int> AcertosFIFO = await Fifo.ExecutaFIFO();
            List<int> AcertosSC   = await Sc.ExecutaSC();
            List<int> AcertosLRU  = await Lru.ExecutaLRU();
            List<int> AcertosNRU  = await Nru.ExecutaNRU();
            List<int> AcertosBEST = await Best.ExecutaBEST();


            ShowResults(Q1, Q2, AcertosFIFO, AcertosSC, AcertosLRU, AcertosNRU, AcertosBEST);

        }


        public void ShowResults(int q1, int q2, List<int> fifo, List<int> sc, List<int> lru,List<int> nru, List<int> best)
        {
            int Q1 = q1;
            int Q2 = q2;
            List<int> FIFO = fifo;
            List<int> SC = sc;
            List<int> LRU = lru;
            List<int> NRU = nru;
            List<int> BEST = best;


            var menuList = new object[FIFO.Count];

            for (int i = 0; i < FIFO.Count; i++)
            {
                menuList[i] = new { Frames = Q1, SC = SC[i], NRU = NRU[i], BEST = BEST[i], FIFO = FIFO[i], LRU = LRU[i] };
                Q1++;

            }


            //mostra acertos na tabela
            tabela.ItemsSource = menuList;


            //mostra acertos no grafico

            LineSeries MySeriesFIFO = new LineSeries();
            LineSeries MySeriesSC = new LineSeries();
            LineSeries MySeriesLRU = new LineSeries();
            LineSeries MySeriesNRU = new LineSeries();
            LineSeries MySeriesBEST = new LineSeries();
            var j = 0;
            for (int i = q1; i <= q2; i++)
            {


                MySeriesSC.MyData.Add(new DataPoint() { Frequency = (double)i, Value = SC[j] });
                MySeriesSC.Name += "Segunda Chance";

                MySeriesNRU.MyData.Add(new DataPoint() { Frequency = (double)i, Value = NRU[j] });
                MySeriesNRU.Name = "NRU";

                MySeriesBEST.MyData.Add(new DataPoint() { Frequency = (double)i, Value = BEST[j] });
                MySeriesBEST.Name = "BEST";

                MySeriesFIFO.MyData.Add(new DataPoint() { Frequency = (double)i, Value = FIFO[j] });
                MySeriesFIFO.Name += "FIFO";

                MySeriesLRU.MyData.Add(new DataPoint() { Frequency = (double)i, Value = LRU[j] });
                MySeriesLRU.Name = "LRU";

                

                

                j++;
                
            }

            
            mydata.Add(MySeriesSC);
            mydata.Add(MySeriesNRU);
            mydata.Add(MySeriesBEST);
            mydata.Add(MySeriesFIFO);
            mydata.Add(MySeriesLRU);


        }


    }

}
