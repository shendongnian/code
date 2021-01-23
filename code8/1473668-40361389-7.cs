    public class Apple : ICloneable
    {
        public string Color { get; set; }
    
        public object Clone()
        {
            return new Apple { Color = Color };
        }
    }
