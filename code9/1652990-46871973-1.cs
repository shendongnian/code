    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Console.Write("Ange antalet heltal du vill lagra i fältet: ");
    
                int heltal = int.Parse(Console.ReadLine());
    
                int[] i = new int[heltal];
    
                Console.WriteLine("Ange " + heltal + " heltal: ");
    
                for (int j = 0; j < i.Length; j++)
                {
                    int o = int.Parse(Console.ReadLine());
                    i[j] = o;
    
                }
    
                Console.WriteLine("Talen utskrivna baklänges: ");
                for (int l = i.Length-1; l >= 0; l--)
                {
    
                    Console.Write(i[l]);
                }
    
    
            }
        }
    }
