    public static void Main()
    {
        int car = 0;
        int length = 0;
        Console.WriteLine("Enter Car Type (TC #): ");
    
        if(!int.TryParse(Console.ReadLine(), out car))
        {
            Console.WriteLine("Not valid number");
            return;
        }
    
         Console.WriteLine("Enter Licience length in months(6 or 12)");
         if(!int.TryParse(Console.ReadLine(), out length))
         {
             Console.WriteLine("Not valid number");
             return;
         }
      
         Console.WriteLine("Enter Emission Band (AA, A, B, C, D): ");
         string band = Console.ReadLine();
    
         Dictionary<Tuple<int,int,string>, decimal> carDataDic = GetCarDetails();
    
         decimal ratio = 0;
    
         Tuple<int, int, string> checkRatioKey = new Tuple<int, int, string>(car, length, band);
    
         if(!carDataDic.TryGetValue(checkRatioKey, out ratio))
         {
             Console.WriteLine("No value found for input data");
             return;
         }
    
         Console.WriteLine("Ratio is: " + ratio);
    }
    
    public static Dictionary<Tuple<int,int,string>, decimal> GetCarDetails()
    {
         Dictionary<Tuple<int,int,string>, decimal> values= new Dictionary<Tuple<int,int,string>, decimal>();
    
         //Tuple Items -> Item1=car, Item2=length, Item3= band), value in Dictionary is the rate which you should have
         values.Add(new Tuple<int, int, string>(49, 6, "AA"), 44);
         values.Add(new Tuple<int, int, string>(49, 6, "A"), 60.5);
         //define all of your cases.
    
         return values;
    }
