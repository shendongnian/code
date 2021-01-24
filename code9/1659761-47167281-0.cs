    class Person
    {
      private static readonly char[] numbers = "0123456789".ToCharArray();
      private static readonly char[] specialChars = "!@#$%^&*()".ToCharArray();
      private string _name;
      public string Name 
      {
         set
         {
            if (Validate(value))
              _name = value;         
         }
         get { return _name; }
      }
      public int age;
      private bool Validate(string input)
      {
         bool isValid = true;
         if (input.IndexOfAny(specialChars) != -1)
         {
            DisplayErrorMessage(input);
            isValid = false;
         } 
         if (input.IndexOfAny(numbers) != -1)
            DisplayWarningMessage(input);
            //optionally set isValid = false if warnings warrant this
         return isValid;
      }
    }
