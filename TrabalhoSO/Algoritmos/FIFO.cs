using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoSO.Algoritmos
{
    public class FIFO
    {
        public int Q1;
        public int Q2;
        public List<int> ListaPag;
        public List<int> AcertosFIFO;
        public List<int> FilaFIFO;


        public FIFO(int q1,int q2, List<int> numero)
        {
            Q1 = q1;
            Q2 = q2;
            ListaPag = numero;

            FilaFIFO = new List<int>();
            AcertosFIFO = new List<int>();
        }

        public async Task<List<int>> ExecutaFIFO()
        {
            Task<List<int>> t = Task<List<int>>.Run(() => FIFOe());

            await t;

            return t.Result;

        }

        private List<int> FIFOe()
        {
            int acertos = 0;
            int posicao = 0;

            while (Q1 <= Q2)
            {
                
                acertos = 0;
                posicao = 0;
                
                
                while (posicao < ListaPag.Count)
                {
                    if (FilaFIFO.Contains(ListaPag[posicao]))
                    {
                        acertos++;
                        posicao++;
                        //ListaPag.RemoveAt(0);
                    }
                    else
                    {
                        if (FilaFIFO.Count < Q1)
                        {
                            FilaFIFO.Add(ListaPag[posicao]);
                            posicao++;
                            //ListaPag.RemoveAt(0);
                        }
                        else
                        {
                            FilaFIFO.RemoveAt(0);
                            FilaFIFO.Add(ListaPag[posicao]);
                            posicao++;
                            //ListaPag.RemoveAt(0);
                        }
                    } 

                    
                }

                AcertosFIFO.Add(acertos);
                FilaFIFO.Clear();
                Q1++;
            }
            
            return AcertosFIFO;

           
        }
    }
}
