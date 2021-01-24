         static void Main(string[] args)
            {
     string input = "My name is ( { Muds } ) My name is MUDS ( { Juan } ) My name is ( { Ortiz Mud } ) otra cosa por aca {juan} pero pues aqui mud {yani}";
                string pattern = @"\{(.*?)\}"; 
    
                string[] substrings = Regex.Split(input, pattern);
    
                for(int i= 0; i <= substrings.Length; i ++)
                {
                    if(i % 2 == 0)
                    {
                        if (substrings[i].ToLower().Contains("mud"))
                        {
                            Console.Write(string.Format("This string has mud outside of brackets. Found in string: {0}", substrings[i].ToString()));
                            Console.Write("\n");
                        }
                    }
                }
    
    
    
                Console.Read();
                
            }
