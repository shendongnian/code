    List<int> testNum = new List<int>();
    int num = 0;
    int sum = 0;
    try
    {
       // This will loop until you have 10 inputs
       while(testNum.Count < 10)
       {
           Console.WriteLine("Enter a number:");
           num = Convert.ToInt32(Console.ReadLine()); // Need to have the Try/Catch in case user doesn't input a number
           testNum.Add(num);
       }
        
       // Get the min and max values (you will need System.Linq for this)
       int minVal = testNum.Min();
       int maxVal = testNum.Max();
       // Remove the min and max values from the List
       testNum.Remove(testNum.IndexOf(minVal));
       testNum.Remove(testNum.IndexOf(maxVal));
       // Sum the remaining values up
       foreach(int n in testNum)
       {
           sum = sum + n;
       }
       return sum;
    }
    catch
    {
        throw;
    }
