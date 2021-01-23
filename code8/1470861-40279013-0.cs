    static void Main(String[] args) 
    {
    double mealCost=Convert.ToDouble(Console.ReadLine());
    int tipPercent=Convert.ToInt32(Console.ReadLine());
    int taxPercent=Convert.ToInt32(Console.ReadLine());
    double tip,tax;
    tip=(mealCost*(tipPercent/100.0));//change 100 to 100.0
    tax=(mealCost*(taxPercent/100.0));//change 100 to 100.0
    double totalCost=mealCost+tip+tax;
    Console.WriteLine("The total meal cost is {0} dollars",totalCost);
    Console.ReadLine();
    }
