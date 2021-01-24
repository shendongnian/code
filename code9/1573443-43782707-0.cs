    using NameSpaceOne;
    using NameSpaceTwo;
    
    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var dupObjectOne = new NameSpaceOne.DuplicateClass() { value = 1};
                var dupObjectTwo = new NameSpaceOne.DuplicateClass() { value = 2 };
            }
        }
    }
    
    namespace NameSpaceOne
    {
        class DuplicateClass
        {
            public int value { get; set; }
        }
    }
    
    namespace NameSpaceTwo
    {
        class DuplicateClass
        {
            public int value { get; set; }
        }
    }
