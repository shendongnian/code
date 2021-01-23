     public static void Main() { 
       // we should scan numbers from 2 to 100
       for (int number = 2; number < 100; ++number) {
         string value = number.ToString();
    
         // digits: just the length of the string: "789" -> 3, "45" -> 2, "7" -> 1
         int digits = value.Length;
    
         // let's sum up the digits
         int sum = 0;
    
         // as we promised: sum up all 4th powers of the digits
         foreach (char c in value) {
           int digit = c - '0'; // notice, that c is character and we want int
    
           sum += Math.Pow(digit, 4);
         } 
           
         // time to output:
         Console.WriteLine("{0, 2}, sum = {1, 5}, digits count = {2, 1}",
           number, sum, digits);
       }
     }
