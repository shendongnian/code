     //DebuggerDisplayAttribute
    [DebuggerDisplay("Value = {Display}")]
    public class Country
    {
        public string Name { get; set; }
        public string City { get; set; }    
    
        public string Display
        {
            get => $"{Name}, {City}";
        }
    
        //Override ToString()
        public override string ToString()
        {
            return $"{Name}, {City}";
        }
    }
