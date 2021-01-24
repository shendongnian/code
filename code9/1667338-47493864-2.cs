    class Program
    {
        static void Main(string[] args)
        {
            string json = @"['Apple','Mango','Orange']";
    
            string[] jsonNew = JsonConvert.DeserializeObject<string[]>(json);            
    
            int[] jsonIntNew = jsonNew.AsEnumerable()
                                      .Select(p => (int)Enum.Parse(typeof(Fruits), p, true))
                                      .ToArray();
    
            Console.Read();
    
        }
    }
    
    public enum Fruits
    {
        Apple = 1,
        Mango = 2,
        Orange = 3
    }
