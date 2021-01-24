    class Program
    {
        static void Main(string[] args)
        {
            int num, sum = 0, r,pos = 0;
            Console.WriteLine("Enter a Number : ");
            num = int.Parse(Console.ReadLine());
		pos = 0;
            while (num != 0)
            { pos++;
                r = num % 10;
                num = num / 10;
                if(pos == 0)||(pos==2)
		 Console.WriteLine("Digit at"+ pos + "is : "+r);
            }
           
            Console.ReadLine();
        }}
