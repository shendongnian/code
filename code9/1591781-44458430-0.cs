    public static void Main(String[] args)
    {
        A v = new Vehicle();
        B v1 = new B();                       
        v1.A = Console.ReadLine();  //Value to be accessed          
        v1.N = Convert.ToInt32(Console.ReadLine());  //Value to be accessed 
        v1.displayDetailInfo();
    }
