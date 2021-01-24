    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        const string OriginalText = "Hello my name is <!name!> and I am <!age!> years old";
        public static void Main()
        {
            var p = new Person();
            p.Age = 18;
            p.Name = "John";
            //Initialize fields dictionary
            var fields = new Dictionary<string, string>();
            foreach (var prop in typeof(Person).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                fields.Add(prop.Name, prop.GetValue(p).ToString());
            }
            ///etc....
