    class Person
    {
      private static readonly char[] numbers = "0123456789".ToCharArray();
      private static readonly char[] specialChars = "!@#$%^&*()".ToCharArray();
      private string _name;
      public string Name 
      {
         set
         {
            if (Validate(value, "Name"))
              _name = value;         
         }
         get { return _name; }
      }
      public int age;
      private bool Validate(string input, string varName)
      {
         bool isValid = true;
         if (input.IndexOfAny(specialChars) != -1)
         {
            Console.WriteLine("Error- " + varName + " contains a special character.");
            isValid = false;
         } 
         if (input.IndexOfAny(numbers) != -1)
            Console.WriteLine("Warning- " + varName + " contains a number.");
            //optionally set isValid = false if warnings warrant this
         return isValid;
      }
    }
