    public class Technology
    {
        public string Name { get; set; }
        public bool IsPortable { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Technology[] list = new Technology[] {
                new Technology() { Name="Smartphone", IsPortable=true },
                new Technology() { Name="Laptop", IsPortable=true },
                new Technology() { Name="Tablet", IsPortable=true },
                new Technology() { Name="Desktop",  IsPortable=false },
                new Technology() { Name="Server",   IsPortable=false },
                new Technology() { Name="Mainframe", IsPortable=false },
            };
            Technology[][] groupedTechnology 
                = list.GroupBy((tech) => tech.IsPortable)
                    .Select((group) => group.ToArray()).ToArray();
        }
    }
