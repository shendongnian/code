        class Program
        {
            static void Main(string[] args)
            {
                 int f = 0,avg=0;
                 Console.WriteLine("enter ammount of tries");
                 int trycount = Convert.ToInt32(Console.ReadLine());
                 Random numgen = new Random();
                 while (f < trycount)
                 {
                     int now = numgen.Next(1, 6);
                     avg = 0 + now;
                     f++;
                 }
                 Console.WriteLine(avg);
                 Console.ReadLine();
              }
         }
