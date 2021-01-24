    internal class TestViewModel
    {
        public string PropertyOne { get; set; }
        public string PropertyTwo { get; set; }
        private string PrivateProperty { get; set; }
        internal string InternalProperty { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //how can I retrieve an IEnumerable with PropertyOne and PropertyTwo ONLY?
            var type = typeof(TestViewModel);
            var properties = type.GetProperties();
            foreach (var p in properties)
                //only prints out the public one
                Console.WriteLine(p.Name);
        }
    }
