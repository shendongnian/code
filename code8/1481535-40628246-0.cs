    static class Program
    {
        static void Main(string[] args)
        {
            Tool to;
            Factory fa;
            Machine ma;
            Module mo;
            List<ArrayList> input = new List<ArrayList>();
            input.Add(new ArrayList() { 1, "facta", 123, "abc" });
            input.Add(new ArrayList() { 2, "facta", 123, "def" });
            input.Add(new ArrayList() { 3, "facta", 123, "ghi" });
            input.Add(new ArrayList() { 4, "facta", 789, "jkl" });
            input.Add(new ArrayList() { 5, "facta", 789, "mno" });
            input.Add(new ArrayList() { 6, "factb", 456, "abc" });
            input.Add(new ArrayList() { 7, "factb", 456, "def" });
            input.Add(new ArrayList() { 8, "factb", 456, "ghi" });
            input.Add(new ArrayList() { 9, "factb", 456, "jkl" });
            input.Add(new ArrayList() { 10, "factb", 456, "mno" });
            //[0] = ToolId / [1] = FactoryName / [2] = MachineName / [3] = ModuleName
            var factories = input.GroupBy(a => a[1]);
            to = new Tool();
            foreach (var factory in factories)
            {
                fa = new Factory($"{factory.First()[1]}");
                var machines = factory.GroupBy(a => a[2]);
                foreach (var machine in machines)
                {
                    ma = new Machine($"{machine.First()[2]}");
                    var modules = machine.GroupBy(a => a[3]);
                    foreach (var module in modules)
                    {
                        mo = new Module($"{module.First()[3]}");
                        ma.Modules.Add(mo);
                    }
                    fa.Machines.Add(ma);
                }
                to.Factories.Add(fa);
            }
        }
    }
    public class Tool
    {
        public List<Factory> Factories { get; set; }
        public Tool()
        {
            Factories = new List<Factory>();
        }
    }
    public class Factory
    {
        public string Name { get; set; }
        public List<Machine> Machines { get; set; }
        public Factory(string name)
        {
            Name = name;
            Machines = new List<Machine>();
        }
    }
    public class Machine
    {
        public string Name { get; set; }
        public List<Module> Modules { get; set; }
        public Machine(string name)
        {
            Name = name;
            Modules = new List<Module>();
        }
    }
    public class Module
    {
        public string Name { get; set; }
        public Module(string name)
        {
            Name = name;
        }
    }
