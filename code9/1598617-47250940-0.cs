    public class Program
        {
            static void Main(string[] args)
            {
                string name = "T@T@P&!M#";
    
                Program obj = new Program();
                
                Console.WriteLine(obj.removeSpecialCharacters(name));
    
                Console.WriteLine(obj.reverseString(obj.removeSpecialCharacters(name)));
    
                Console.ReadLine();
    
    
            }
    
            private string removeSpecialCharacters(string input)
            {
                string[] specialCharacters = new string[] { "@", "&", "!", "#" };
    
                for (int i = 0; i < specialCharacters.Length; i++)
                {
                    if (input.Contains(specialCharacters[i]))
                    {
                        input = input.Replace(specialCharacters[i], "");
                    }
                }
    
                return input;
            }
    
            private string reverseString(string input)
            {
                string reverseString = "";
    
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reverseString = reverseString + input[i];
                }
    
                return reverseString;
            }
        }
