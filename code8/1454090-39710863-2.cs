    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace euro_to_dollar
    {
    class Program
    {
        static void Main(string[] args)
        {
            float dollars, conversion_rate, euros;
            conversion_rate = 1.12f;
            Console.WriteLine("Enter in Dollars:");
            dollars = float.Parse(Console.ReadLine());
            euros = dollars * conversion_rate;
            Console.WriteLine("Dollars:" + euros);
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
