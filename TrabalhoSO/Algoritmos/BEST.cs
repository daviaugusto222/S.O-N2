using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoSO.Algoritmos
{
    public class BEST
    {
        public int Q1;
        public int Q2;
        public int ZerarBitR;
        public List<int> ListaPag;
        public List<string> Operacoes;



        public List<int> AcertosBEST;
        public List<int> FilaBEST;
        public List<int> ValoresRef;
        public List<int> BitM;



        public BEST(int q1, int q2,  List<int> numero)
        {
            Q1 = q1;
            Q2 = q2;
            
            ListaPag = numero;
            

            FilaBEST = new List<int>();
            AcertosBEST = new List<int>();
            ValoresRef = new List<int>();
            BitM = new List<int>();
            
        }


        public async Task<List<int>> ExecutaBEST()
        {
            Task<List<int>> t = Task<List<int>>.Run(() => BESTe());

            await t;

            return t.Result;

        }

        private List<int> BESTe()
        {
            int acertos = 0;
           



            for (int i = Q1; i <= Q2; i++) // se repete de Q1 ate Q2, página inical ao página final
            {
                for (int k = 0; k < ListaPag.Count; k++) //caminha pela lista de referencias
                {

                    if (FilaBEST.Contains(ListaPag[k])) //se a pagina ja esta na memoria
                    {
                        acertos++;
                    }
                    else
                    {
                        if (FilaBEST.Count < i) //verifica se a memoria está cheia
                        {
                            FilaBEST.Add(ListaPag[k]);
                            ValoresRef.Add(0);
                        }
                        else
                        {//falta de pagina

                            for (int t = 0; t < FilaBEST.Count; t++)
                            {
                                ValoresRef[t] = 0;
                                for (int e = k; e < ListaPag.Count; e++)
                                {
                                    ValoresRef[t] += 1;
                                    if (FilaBEST[t] == ListaPag[e])
                                    {
                                        break;
                                    }

                                }


                            }
                            for (int y = 0; y < FilaBEST.Count; y++)
                            {
                                
                                if (ValoresRef.Max() == ValoresRef[y])
                                {
                                    FilaBEST.RemoveAt(y);
                                    ValoresRef.RemoveAt(y);

                                    FilaBEST.Add(ListaPag[k]);
                                    ValoresRef.Add(0);

                                    break;
                                }

                            }
                           


                        }
                    }




                }

                AcertosBEST.Add(acertos);

                //zera fila SC
                FilaBEST.Clear();

                //zera fila bitR e bitM
                ValoresRef.Clear();
                BitM.Clear();

                acertos = 0;
                
            }

            return AcertosBEST;
        }

        private bool TrocaPagina(int k, int g)
        {



            FilaBEST.RemoveAt(g);
            ValoresRef.RemoveAt(g);
            BitM.RemoveAt(g);

            FilaBEST.Add(ListaPag[k]);
            ValoresRef.Add(1);

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

