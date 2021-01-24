     static void Main(string[] args)
        {
            string input = "My name is ( { Muds } ) My name is ( { Juan } ) My name is ( { Ortiz } ) otra cosa por aca {juan} pero pues aqui mud {jose}";
            string pattern = @"\{(.*?)\}"; 
            string[] substrings = Regex.Split(input, pattern);
            
            for(int i= 0; i <= substrings.Length; i ++)
            {
                if(i % 2 == 0)
                {
                    if (substrings[i].Contains("mud"))
                        Console.Write(string.Format("This string has mud outside of brackets. Found in string: {0}", substrings[i].ToString())); 
                }
            }
            Console.Read();
            
        }
