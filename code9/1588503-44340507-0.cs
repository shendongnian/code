    using System;
    namespace ConsoleApp7
    {
        public class Program
        {
            public static void Main(string[] args)
            {
            Console.WriteLine("Enter numbers separate by hypen : ");
            var name = Console.ReadLine();
            var numarray = name.Split('-');
			int firstValue = Convert.ToInt32(numarray[0]);
			
			bool cons = true;
			for (var i = 0;i<numarray.Length;i++ )
			{
				if (Convert.ToInt32(numarray[i])-i != firstValue)
				{
					cons = false;					
					break;
				}
			}
			if (cons)
			{
				Console.WriteLine("Consecutive");
			}
			else
			{
				Console.WriteLine("Not Consecutive");
			}
        }
    }
