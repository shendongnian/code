    static void Main(string[] args)
            {
    
                string remainingBits = "010011010100110101000101010011010100110101001101010011010100110101101111";
                List<string> octetCollection = new List<string>();
                for (int i = 0; i < remainingBits.Length / 8; i++)
                {
                    octetCollection.Add(remainingBits.Substring(i * 8, 8));
                }
    
                foreach (var s in octetCollection)
                {
                    //Do whatever action on each octet
                    Console.WriteLine(s);
                }
                Console.WriteLine("Count: " + octetCollection.Count.ToString());
                Console.ReadLine();
            }
