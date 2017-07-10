using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoSO.Algoritmos
{
    public class NRU
    {
        public int Q1;
        public int Q2;
        public int ZerarBitR;
        public List<int> ListaPag;
        public List<string> Operacoes;



        public List<int> AcertosNRU;
        public List<int> FilaNRU;
        public List<int> BitR;
        public List<int> BitM;


        public NRU(int q1,int q2, int zerarbitr, List<int> numero, List<string> operacoes)
        {
            Q1 = q1;
            Q2 = q2;
            ZerarBitR = zerarbitr;
            ListaPag = numero;
            Operacoes = operacoes;

            FilaNRU = new List<int>();
            AcertosNRU = new List<int>();
            BitR = new List<int>();
            BitM = new List<int>();
        }


        public async Task<List<int>> ExecutaNRU()
        {
            Task<List<int>> t = Task<List<int>>.Run(() => NRUe());

            await t;

            return t.Result;

        }

        private List<int> NRUe()
        {
            int acertos = 0;
            int zerar = 0;



            for (int i = Q1; i <= Q2; i++)
            {
                for (int k = 0; k < ListaPag.Count; k++)
                {

                    if (FilaNRU.Contains(ListaPag[k])) //se a pagina ja esta na memoria
                    {
                        acertos++;

                        for (int j = 0; j < FilaNRU.Count; j++)
                        {
                            if (FilaNRU[j] == ListaPag[k])
                            {
                                
                                BitR[j] = 1;
                                //so pode mudar bit m de 0 para 1
                                if (BitM[j] == 0 && Operacoes[k] == "W")
                                {
                                    BitM[j] = 1;
                                }
                                break;

                            }
                        }

                    }
                    else
                    {
                        if (FilaNRU.Count < i)
                        {
                            
                            FilaNRU.Add(ListaPag[k]);
                            BitR.Add(1);

                            if (Operacoes[k] == "W")
                            {
                                BitM.Add(1);
                            }
                            else
                            {
                                BitM.Add(0);
                            }
                           

                        }
                        else
                        {//falta de pagina
                            var p = true;
                            while (p)
                            {
                                for (int g = 0; g < FilaNRU.Count; g++)
                                {
                                    if (BitR[g] == 0 && BitM[g] == 0)
                                    {
                                        p = TrocaPagina(k, g);
                                        break;
                                    }
                                }
                                if (p == false) break;
                                for (int g = 0; g < FilaNRU.Count; g++)
                                {
                                    if (BitR[g] == 0 && BitM[g] == 1)
                                    {
                                        p = TrocaPagina(k, g);
                                        break;
                                    }
                                }
                                if (p == false) break;
                                for (int g = 0; g < FilaNRU.Count; g++)
                                {
                                    if (BitR[g] == 1 && BitM[g] == 0)
                                    {
                                        p = TrocaPagina(k, g);
                                        break;
                                    }
                                }
                                if (p == false) break;
                                for (int g = 0; g < FilaNRU.Count; g++)
                                {
                                    if (BitR[g] == 1 && BitM[g] == 1)
                                    {
                                        p = TrocaPagina(k, g);
                                        break;
                                    }
                                }
                                if (p == false) break;
                            }


                        }
                    }


                    zerar++;
                    if (zerar == ZerarBitR)
                    {
                        for (int p = 0; p < BitR.Count; p++)
                        {
                            BitR[p] = 0;

                        }

                        zerar = 0;
                    }

                }

                AcertosNRU.Add(acertos);
                //zera fila SC
                FilaNRU.RemoveRange(0, FilaNRU.Count());

                //zera fila bitR
                BitR.RemoveRange(0, BitR.Count());
                BitM.RemoveRange(0, BitM.Count());

                acertos = 0;
                zerar = 0;
            }
            return AcertosNRU;
        }

        private bool TrocaPagina(int k, int g)
        {
            
            

            FilaNRU.RemoveAt(g);
            BitR.RemoveAt(g);
            BitM.RemoveAt(g);

            FilaNRU.Add(ListaPag[k]);
            BitR.Add(1);

            if (Operacoes[k] == "W")
            {
                BitM.Add(1);
            }
            else
            {
                BitM.Add(0);
            }
              
            

            return false;  
        }
    }
}
