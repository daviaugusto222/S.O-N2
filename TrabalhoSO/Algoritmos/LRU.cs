using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoSO.Algoritmos
{
    public class LRU
    {

        public int Q1;
        public int Q2;
        public List<int> ListaPag;
        public List<int> AcertosLRU;
        public List<int> FilaLRU;

        public LRU(int q1, int q2, List<int> numero)
        {
            Q1 = q1;
            Q2 = q2;
            ListaPag = numero;

            FilaLRU = new List<int>();
            AcertosLRU = new List<int>();
        }


        public async Task<List<int>> ExecutaLRU()
        {
            Task<List<int>> t = Task<List<int>>.Run(() => LRUe());

            await t;

            return t.Result;

        }

        private List<int> LRUe()
        {
            int acertos = 0;
    

            for (int i = Q1; i <= Q2; i++)
            {
                foreach (var num in ListaPag)
                {
                    if (FilaLRU.Contains(num))
                    {
                        acertos++;

                        for (int j = 0; j < FilaLRU.Count; j++)
                        {
                            if(FilaLRU[j] == num)
                            {
                                FilaLRU.RemoveAt(j);
                                FilaLRU.Add(num);
                            }

                        }
                    }
                    else
                    {
                        if (FilaLRU.Count < i)
                        {
                            FilaLRU.Add(num);
                        }
                        else
                        {
                            FilaLRU.RemoveAt(0);
                            FilaLRU.Add(num);
                        }
                    }

                }


                AcertosLRU.Add(acertos);
                acertos = 0;
                FilaLRU.RemoveRange(0, FilaLRU.Count());


            }

            return AcertosLRU;


        }


    }
}
