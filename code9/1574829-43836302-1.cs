    public class Program
    {
        [Export(typeof(Person))]
        private Person personToInject { get; set; }
    
        public static void Main(string[] args)
        {
            new Program().Run();
        }
        private void Run()
        {
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);
            
            //Create the person to inject before composing
            personToInject = new Person();        
    
            container.ComposeParts(this);
        }
    }
