    class Program
    {
        static void Main(string[] args)
        {
            IStruct s1 = new Struct1();
            IStruct s2 = new Struct2();
            EditStruct(ref s1);
            EditStruct(ref s2);
        }
        static void EditStruct(ref IStruct target)
        {
            target.Name = Guid.NewGuid().ToString();
        }
    }
    public interface IStruct
    {
        string Name { get; set; }
    }
    public struct Struct1 : IStruct
    {
        public string Name { get; set; }
    }
    public struct Struct2: IStruct
    {
        public string Name { get; set; }
    }
