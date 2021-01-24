      class Program
        {
            static void Main(string[] args)
            {
                var example = new Example() { Name = "Name"};
                Console.WriteLine(example.Name);
    
                WrongStructModifier(example);
                Console.WriteLine(example.Name);
    
                CorrectStructModifier2(ref example);
                Console.WriteLine(example.Name);
            }
    
            static void WrongStructModifier(Example example)
            {
                example.Name = "Modified Name";
            }
    
            static void CorrectStructModifier2(ref Example example)
            {
                example.Name = "Modified Name";
            }
        }
    
        struct Example
        {
            public string Name;
        }
