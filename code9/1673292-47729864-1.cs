    public class OilVolume
    {
        public int Volume { get; set; }
        public string Name { get; set; }
        public OilVolume(string name, int value)
        {
            this.Name = name;
            this.Volume = value;
        }
        public override string ToString(){
            return $"{Name} {Volume}";
        }
    }
