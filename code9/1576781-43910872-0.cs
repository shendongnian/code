    class Program
    {
        static void Main(string[] args)
        {
            var sentence = "dancing sentence large also";
            string newString = string.Empty;
            StringBuilder newStringdata = new StringBuilder();
            string[] arr = sentence.Split(' ');
            for (int i=0; i< arr.Length;i++)
            {
                if (i==0)
                {
                    newString = ReturnEvenModifiedString(arr[i]);
                    newStringdata.Append(newString);
                }
                else
                {
                    if(char.IsUpper(newString[newString.Length - 1]))
                    {
                        newString = ReturnOddModifiedString(arr[i]);
                        newStringdata.Append(" ");
                        newStringdata.Append(newString);
                    }
                    else
                    {
                        newString = ReturnEvenModifiedString(arr[i]);
                        newStringdata.Append(" ");
                        newStringdata.Append(newString);
                    }
                }
            }
            Console.WriteLine(newStringdata.ToString());
            Console.Read();
        }
        //For Even Test
        private static string ReturnEvenModifiedString(string initialString)
        {
            string newString = string.Empty;
            var temparr = initialString.ToCharArray();
            for (var i = 0; i < temparr.Length; i++)
            {
                if (temparr[i] != ' ')
                {
                    if (i % 2 == 0 && temparr[i] != ' ')
                    {
                        newString += temparr[i].ToString().ToUpper();
                    }
                    else
                    {
                        newString += temparr[i].ToString().ToLower();
                    }
                }
            }
            return newString;
        }
       
        //For Odd Test
        private static string ReturnOddModifiedString(string initialString)
        {
            string newString = string.Empty;
            var temparr = initialString.ToCharArray();
            for (var i = 0; i < temparr.Length; i++)
            {
                if (temparr[i] != ' ')
                {
                    if (i % 2 != 0 && temparr[i] != ' ')
                    {
                        newString += temparr[i].ToString().ToUpper();
                    }
                    else
                    {
                        newString += temparr[i].ToString().ToLower();
                    }
                }
            }
            return newString;
        }
    }
