    Public class Cow : Animal
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name/*+ other properties*/;
        }
    }
