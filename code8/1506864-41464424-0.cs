        class Program
        {
            static void Main(string[] args)
            {
                StringBuilder s = new StringBuilder("object");
                Console.WriteLine("orignal string ={0}", s);
                Console.WriteLine("string length  ={0}", s.Length);
                //appending string
                s.Append(" languge");
                Console.WriteLine("after appending={0}", s);
                //inserting string
                s.Insert(7, " oriented ");
                Console.WriteLine("after inserting={0}", s);
                //setting a character
                int n = s.Length;
                s[n - 1] = '!';
                Console.WriteLine("final string   ={0}", s);
                length(s.ToString());
                Console.ReadLine();
            }
            static string length(string d)
            {
                int a = d.Length;
                return (a.ToString());
            }
        }
