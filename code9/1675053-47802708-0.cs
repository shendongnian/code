    static void Main(string[] args)
        {
            Console.Write("Which decimal number do you want to convert into binary :  ");
            long nr_dec = long.Parse(Console.ReadLine());            
            
            var nrbin = new List<long>();           
            while (nr_dec > 1)
            {
                var bin = nr_dec % 2;
                nrbin.Add(bin);                
                nr_dec /= 2;               
            }           
            nrbin.Add(1);
            nrbin.Reverse();
            foreach (var num in nrbin)
            {
                Console.Write(num);
            }           
            Console.ReadKey();
        }
