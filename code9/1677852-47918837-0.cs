    static void Main(string[] args)
    {
        int[] arryofdays = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
        int num = Int32.Parse(Console.ReadLine()); //40
        int days = 0;
        int months = 0;
    
    
        for (int i = 0; i < arryofdays.Length; i++) {
            if (num > arryofdays[i]) {
                num -= arryofdays[i];
                months++;            
            } else {
                days = num;
            }
        }
    
        Console.WriteLine("Date:" + days.ToString());
        Console.WriteLine("Month:" + (months+1).ToString());
    
        Console.ReadLine();
    }
