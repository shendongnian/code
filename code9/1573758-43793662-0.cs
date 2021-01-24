    using System.IO;
    using System;
    
    class Program {
     static void Main() {
      Console.WriteLine("How many numbers do you wish to calculate? ");
      string HowMany = Console.ReadLine();
    
      int[] nums = new int[int.Parse(HowMany)];
      int sum = 0, sub = 0, mult = 1, div = 1;
      for (int i = 0; i < int.Parse(HowMany); i++) {
       Console.Write("Enter #" + (i + 1) + ": ");
       nums[i] = int.Parse(Console.ReadLine());
       sum += nums[i];
       sub -= nums[i];
       mult *= nums[i];
       div /= nums[i];
      }
    
      Console.WriteLine("The Result : Sum = " + sum + " Sub = " + sub + " Mult = " + mult + " Div = " + div);
    
      Console.ReadKey();
     }
    }
