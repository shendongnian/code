    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		double[,] tabel_nilai = new double[,]{   {3500, 70, 10, 80, 3000, 36},
                                                        {4500, 90, 10, 60, 2500, 48 },
                                                        {4000, 80, 9, 90, 2000, 48 },
                                                        {4000, 70, 8, 50, 1500, 60 }};	
    
    		for (int j = tabel_nilai.GetLowerBound(1); j <= tabel_nilai.GetUpperBound(1); j++)
            {
    			var seekingMax = ((j - tabel_nilai.GetLowerBound(1)) % 2) == 0;
    			var maxmin = tabel_nilai[0, j];
    
    			for(int i = tabel_nilai.GetLowerBound(0) + 1; i <= tabel_nilai.GetUpperBound(0); i++)
                {
    				if (seekingMax)
    				{
                    	maxmin = Math.Max(maxmin,tabel_nilai[i, j]);
    				}
    				else
    				{
                    	maxmin = Math.Min(maxmin,tabel_nilai[i, j]);
    				}
                }
    			
    			Console.WriteLine("{0}: {1}", seekingMax ? "Max" : "Min", maxmin);
            }
    	}
    }
