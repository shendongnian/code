      double[][] tabel_nilai = new double[][]{ new double[] {3500, 70, 10, 80, 3000, 36},
                               new double[] {4500, 90, 10, 60, 2500, 48 },
                               new double[] {4000, 80, 9, 90, 2000, 48 },
                               new double[] {4000, 70, 8, 50, 1500, 60 }
                   };
                
    double[] pembagi = new double[6];
    maxMin maxMinObj;
    for (int i = 0; i < 6; i++)
    {
    if( i == 0)
                            maxMinObj = x => x.Max();
                        else
                            maxMinObj = x => x.Min();
                   
                        pembagi[i] = maxMinObj(tabel_nilai[i]);
                    
                    Console.WriteLine(pembagi[i]);           
                }
            }
