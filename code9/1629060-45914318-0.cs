    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Randomy1
    {
        class Program
    {
        static void Main(string[] args)
        {
            int[] tablica1 = new int[20];
            Random tab = new Random();
            for (int i = 0; i < 20; i++)
            {
                tablica1[i] = tab.Next(20);
                Console.WriteLine(tablica1[i]);
            }
            
           
            int[] tablica2 = new int[20];
           for (int j = tablica2.Length; j > 1 ; j--)
            {
                tablica2[j] = tablica1[20-j];
                Console.WriteLine(tablica2[j]);
            }
            Console.Read();
        }
    }
    } 
