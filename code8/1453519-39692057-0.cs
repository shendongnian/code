      static void Main(string[] args)
    {
        string x;               
        double t, s = 1;
        while ((x = Console.ReadLine()) != null)
        {        
            if(double.TryParse(x,out t))
            {
                //t is now the number entered as a double -- process
            }else{
                Console.WriteLine("You may only enter numbers. Please try again.\n");
            }
        }
