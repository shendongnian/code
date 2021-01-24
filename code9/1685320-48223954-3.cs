    class Program
    {
        static void Main()
        {
            string input = "I'm learning C#";
            string[] result = new string[3];
    
            int arrayIndex = 0;
            string tempStr = "";
    
            // Split string 
            for (int i = 0; i < input.Length; i++)
            {
                tempStr += input[i].ToString();   
                if (input[i] != ' ')
                {
                    result[arrayIndex] = tempStr;
                }
                else
                {
                    tempStr = "";
                    arrayIndex++;
                }
            }
    
            // Display Result
            for (int i = result.Length - 1; i >= 0; i--)
            {
                System.Console.Write(result[i] + ' ');
            }
            System.Console.WriteLine();
        }
    }
