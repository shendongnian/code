    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Labb2._2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Mata in ett tal: ");
    
                string talen;
    
                talen = Console.ReadLine();
    
                int tal = int.Parse(talen);
    
    if (tal  % 3 == 0 && tal % 7 == 0 )
    {
              Console.Write("The number is divisible with 3 and 7 {0} {1}.", tal / 3 , tal / 7);
    }
