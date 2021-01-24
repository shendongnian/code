    static void Main(string[] args)
            {
                string json = @"['Apple','Mango','Orange']";
    
                //string[] jsonNew = JsonConvert.DeserializeObject<string[]>(json);            
    
                int[] jsonIntNew = JsonConvert.DeserializeObject<string[]>(json).AsEnumerable().Select(p => (int)Enum.Parse(typeof(Fruits), p, true)).ToArray();
    
                Console.Read();
    
            }
