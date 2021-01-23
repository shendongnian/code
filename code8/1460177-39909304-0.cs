    //You can use this...
    using System.Globalization;
 
    namespace ConsoleApplication7
    {
    class Program
    {
    static void Main(string[] args)
    {
            double TotalAmount;
            TotalAmount = 300.7 + 75.60;
                        string YourBalance = "Your account currently
          contains   this much money:  " + string.Format
           (new   CultureInfo("en-US"), "{0:C}",TotalAmount);
            Console.WriteLine(YourBalance);
            Console.ReadLine();
          }
       }
       }
