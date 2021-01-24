    class MyIntEntity : ModelBase<int>
    {
        public new int Id { get; set; }
    }
    class MyStringEntity : ModelBase<string>
    {
        public new string Id { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var repoIntegerKey = new Repo<MyIntEntity>();
            var repoStringKey = new Repo<MyStringEntity>();
            repoIntegerKey.Test(); // prints "MyIntEntity        Int32"
            repoStringKey.Test();  // prints "MyStringEntity     String"
            Console.ReadLine();
        }        
    }
