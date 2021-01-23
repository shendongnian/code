      static void Main(string[] args)
    {
        string x;               
        double t,tot=0, s = 1;
        while ((x = Console.ReadLine()) != null)
        {        
            if(double.TryParse(x,out t))
            {
                //t is now the number entered as a double -- process
                tot+= t;
                Console.WriteLine(s==1?"Please enter your second number":"The sum of your "+s.ToString()+" numbers is "+tot.ToString("N0"));
                s++;
            }else{
                Console.WriteLine("You may only enter numbers. Please try again.\n");
            }
        }
