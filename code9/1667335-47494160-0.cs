    class Program
            {
                static void Main(string[] args)
                {            
                    string input = "sudar";
        
                    string encodedInput = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
                    string decodedInput = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(encodedInput));
        
                    Console.WriteLine("Actual text:" + input);
                    Console.WriteLine("Encrypted Value: " + encodedInput);
                    Console.WriteLine("Decrypted Value: " + decodedInput);
        
                    List<string> encryptedList = new List<string>();
        
                    Console.WriteLine("Encrypted Data:");
        
                    foreach (char c in input.ToCharArray())
                    {
                        string encryptedValue = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(c.ToString()));
                        Console.WriteLine(c + " replaced by " + encryptedValue);
                        encryptedList.Add(encryptedValue);
                    }
        
                    Console.WriteLine("Decrypted Data:");
                    foreach (string s in encryptedList)
                    {
                        string decryptedValue = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(s));
                        Console.WriteLine(s + " replaced by " + decryptedValue);
                    }
        
                    Console.Read();
        
                }
            }
