using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoSO.Algoritmos
{
    public class SC
    {
        public int Q1;
        public int Q2;
        public int ZerarBitR;
        public List<int> ListaPag;
        public List<string> Operacoes;
        


        public List<int> AcertosSC;
        public List<int> FilaSC;
        public List<int> BitR;


        public SC(int q1, int q2, int zerarbitr,List<int> numero, List<string> operacoes)
        {
            Q1 = q1;
            Q2 = q2;
            ZerarBitR = zerarbitr;
            ListaPag = numero;
            Operacoes = operacoes;

            FilaSC = new List<int>();
            AcertosSC = new List<int>();
            BitR = new List<int>();
        }

        public async Task<List<int>> ExecutaSC()
        {
            Task<List<int>> t = Task<List<int>>.Run(() => SCe());

            await t;

            return t.Result;

        }

        private List<int> SCe()
        {
            int acertos = 0;
            
            int zerar = 0;



            for (int i = Q1; i <= Q2; i++)
            {



                foreach (var posicao in ListaPag)
                {

                    if (FilaSC.Contains(posicao)) //se a pagina ja esta na memoria
                    {
                        acertos++;
                        for (int j = 0; j < FilaSC.Count; j++)
                        {
                            if (FilaSC[j] == posicao)
                            {
                                int x = 1;
                                BitR[j] = x;
                            }
                        }
                        
                    }
                    else
                    { 
                        if (FilaSC.Count <i)
                        {
                            int x = 1;
                            FilaSC.Add(posicao);
                            BitR.Add(x);
                            
                        }
                        else
                        {//falta de pagina
                            var tr = true;
                            while (tr)
                            {
                                if (BitR.First() == 1)
                                {

                                    var primeiro = FilaSC.First();
                                    
                                    FilaSC.RemoveAt(0);
                                    BitR.RemoveAt(0);

                                    FilaSC.Add(primeiro);
                                    var x = 0;
                                    BitR.Add(x);

                                }
                                else
                                {
                                    FilaSC.RemoveAt(0);
                                    BitR.RemoveAt(0);
                                    FilaSC.Add(posicao);
                                    var x = 1;
                                    BitR.Add(x);
                                    

                                    tr = false;
                                }

                                

                            }

                        }
                    }


                    zerar++;
                    if (zerar == ZerarBitR)
                    {
                        for (int k = 0; k < BitR.Count; k++)
                        {
                            BitR[k] = 0;
                            
                        }

                        zerar = 0;
                    }

                }

                AcertosSC.Add(acertos);
                //zera fila SC
                FilaSC.Clear();
                //zera fila bitR
                BitR.Clear();

                acertos = 0;
                zerar = 0;
               
                


                
            }

            return AcertosSC;


        }
    }
}
