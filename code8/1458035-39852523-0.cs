    public class PropertyInitialization
    {
        public virtual string First { get; set; }
        public PropertyInitialization()
        {
            this.First = "Adam";
        }
    }
    public class ZopertyInitalization : PropertyInitialization
    {
        public override string First
        {
            get { return base.First; }
            set
            {
                Console.WriteLine($"Child property hit with the value: '{0}'");
                base.First = value;
            }
        }
    }
