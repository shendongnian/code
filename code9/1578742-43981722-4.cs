    static public void Searching(int[] arr)
        {
            string x = "yes";
    
            Console.WriteLine("Please enter a number for which to search...");
            int target = Convert.ToInt32(Console.ReadLine());
            string result = string.Empty
            for(int i =0; i < arr.Length; i++)
                  if (i = target)
                  { result += i.ToString() + ", " }
            }
            if(result != string.Empty)
            {
               result = result.SubString(0, result.Length - 2);
               //removes extra space and colon
            } else {
               result = "Not Found";
            }
            Console.WriteLine("Result of search is:"
            + result);
         }
