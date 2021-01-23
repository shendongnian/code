      public static int SumNumber(string number)
            {
    
               if(string.IsNullOrEmpty(number))
                    return 0;
               else if(number.Length == 1)
                    return int.Parse(number);
               else
                   return SumNumber(number.Substring(1)) + int.Parse(number.Substring(0, 1));
            }
