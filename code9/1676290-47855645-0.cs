    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    namespace DozeFilastres
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> lines = new List<string>();
                int[] finarr = new int[]{0,0,0,0,0,0,0,0,0,0,0,0};
                int aux=0;
            
                while(finarr[11]!=3)
                {
                    finarr[0]=aux;
                    lines.Add(printarr(finarr));
                    aux++;
                    if(aux==3)
                    {
                        aux=0;
                        finarr[0]++;
                        for(int idx=0;idx<11;idx++)
                        {
                            if(finarr[idx]==3)
                            {
                                finarr[idx]=0;
                                finarr[idx+1]++;
                            }
                        }
                    }
                }
            
                File.WriteAllLines("fichero.txt",lines.ToArray());
            }
            static string printarr(int[] arr)
            {
                string all="Ans = {";
                for(int idx=0;idx<12;idx++)
                {
                    if(idx!=0)
                        all+=",";
                    switch(arr[idx])
                    {
                    case 0:
                        all+="1,0,0";
                        break;
                    case 1:
                        all+="0,1,0";
                        break;
                    case 2:
                        all+="0,0,1";
                        break;
                    }
                }
                all+="}";
                return all;
            }
        }
    }
