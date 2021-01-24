    public enum Parameters { A, B, C, D, E }
    // Class specifies for itself the mandatory and optional
    public class Foo
    {
        public IEnumerable<Parameters> Mandatory { get; set; } = new List<Parameters> { A, B };
    
        public IEnumerable<Parameters> Optional { get; set; } = new List<Parameters> { C, D };
    }
    
    // Class receives what are the mandatory and optional
    public class Bar
    {
        public Bar(IEnumerable<Parameter> optional, IEnumerable<Parameter> mandatory)
        {
            // store input
        }
    }
