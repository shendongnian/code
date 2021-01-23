    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace _010029428_Multiplicacion
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    
    			int i, j, m, n;
    			Random rnd = new Random((int)DateTime.Now.Ticks & 0x000fff);
    			Console.WriteLine("Ingrese el numero de renglones y columnas: ");
    			m = Convert.ToInt32(Console.ReadLine());
    			n = Convert.ToInt32(Console.ReadLine());
    			int[,] a = new int[m, n];
    			Console.WriteLine("first Matrix");
    			for (i = 0; i < m; i++)
    			{
    				for (j = 0; j < n; j++)
    				{
    					a[i, j] = rnd.Next(1, 4);
    				}
    			}
    			Console.WriteLine("First matrix is: ");
    			for (i = 0; i < m; i++)
    			{
    				for (j = 0; j < n; j++)
    				{
    					Console.Write(a[i, j] + "\t");
    				}
    				Console.WriteLine();
    			}
    			int[,] b = new int[m, n];
    			Console.WriteLine("Second Matrix: ");
    			for (i = 0; i < m; i++)
    			{
    				for (j = 0; j < n; j++)
    				{
    					b[i, j] = rnd.Next(1, 4);
    				}
    			}
    			Console.WriteLine("The second matrix is:");
    			for (i = 0; i < n; i++)
    			{
    				for (j = 0; j < n; j++)
    				{
    					Console.Write(b[i, j] + "\t");
    				}
    				Console.WriteLine();
    			}
    
    			Console.WriteLine("The result is :");
    			int[,] c = new int[m, n];
    
    			Task[] tasks = new Task[m];
    			for (i = 0; i < m; i++)
    			{
    				var multiplicacion = new Task((parameter) =>
    				{
    					int ii = (int)parameter;
    
    					for (int jj = 0; jj < n; jj++)
    					{
    						c[ii, jj] = 0;
    						for (int k = 0; k < n; k++)
    						{
    							c[ii, jj] += a[ii, k] * b[k, jj];
    						}
    					}
    				},
    				i);
    				tasks[i] = multiplicacion;
    				multiplicacion.Start();
    			}
    
    			Task.WaitAll(tasks);
    
    			for (i = 0; i < m; i++)
    			{
    				for (j = 0; j < n; j++)
    				{
    					Console.Write(c[i, j] + "\t");
    				}
    				Console.WriteLine();
    			}
    			Console.ReadLine();
    		}
    	}
    }
