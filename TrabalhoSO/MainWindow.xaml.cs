using Microsoft.Win32;
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

        public MainWindow()
        {
            InitializeComponent();

            numero = new List<int>();
            operacao = new List<string>();


           
        }

        private async void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {

            Q1 = Int32.Parse(Q1text.Text);
            Q2 = Int32.Parse(Q2text.Text);
            ZerarBitR = Int32.Parse(ZerarBitRtext.Text);


            OpenFileDialog openFileDialog = new OpenFileDialog();

            //define as propriedades do controle 
            //OpenFileDialog
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Selecionar Arquivo";
            openFileDialog.InitialDirectory = @"C:\";
            //filtra para exibir somente arquivos de imagens
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ReadOnlyChecked = true;
            openFileDialog.ShowReadOnly = true;


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

            //começa treads'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            FIFO Fifo = new FIFO(Q1, Q2, numero);
            SC Sc     = new SC  (Q1, Q2, ZerarBitR, numero, operacao);
            LRU Lru   = new LRU (Q1, Q2, numero);
            NRU Nru   = new NRU (Q1, Q2, ZerarBitR, numero, operacao);

            List<int> AcertosFIFO = await Fifo.ExecutaFIFO();
            
            List<int> AcertosSC = await Sc.ExecutaSC();

            List<int> AcertosLRU = await Lru.ExecutaLRU();

            List<int> AcertosNRU = await Nru.ExecutaNRU();


            ShowResults(Q1, Q2, AcertosFIFO, AcertosSC, AcertosLRU, AcertosNRU);

        }


        public void ShowResults(int q1, int q2, List<int> fifo, List<int> sc, List<int> lru,List<int> nru)
        {
            int Q1 = q1;
            int Q2 = q2;
            List<int> FIFO = fifo;
            List<int> SC = sc;
            List<int> LRU = lru;
            List<int> NRU = nru;


            var menuList = new object[FIFO.Count];

            for (int i = 0; i < FIFO.Count; i++)
            {
                menuList[i] = new { Frames = Q1, SC = SC[i], NRU = NRU[i], BEST = 0, FIFO = FIFO[i], LRU = LRU[i] };
                Q1++;

            }


            //mostra acertos na tabela
            tabela.ItemsSource = menuList;
            

            //mostra acertos no grafico
        }


    }

}
