    public class Control : IGrid
        {
            public virtual string Text
            {
                get { return "Hello Control!"; }
                
            }
    
            public virtual void Click()
            {
                Console.WriteLine("In the Control!");
            }
        }
    public class SelectList : Control, IGrid
    {
        public int Number { get; set; }
        public override string Text
        {
            get
            {
                return "Hello Select!";
            }
            
        }
        public override void Click()
        {
            Console.WriteLine("In the Select!");
        }
    }
