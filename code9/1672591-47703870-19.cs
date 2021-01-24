    // the class represents a single object, give it a
    // singular name
    public class Plane
    {
        // get before set, it's not mandatory but give yourself
        // some basic coding rules to improve code maintainability
        // and readability
        // avoid public members, implementing properties is always
        // a good choice for future extensions and manipulations
        public int Fuel { get; private set; }
        public int Tons { get; private set; }
        public string Name { get; private set; }
    
        public Plane(string name, int fuel, int tons)
        {
            Name = name;
            Fuel = fuel;
            Tons = tons;
        }
    }
    
    // if your inheritance stops here, you could set a
    // sealed attribute
    public sealed class Boeing737 : Plane
    {
        // no need to set the property twice, you are already
        // calling the base constructor, pass him the fixed
        // tons value of 700...
        public Boeing737(string name, int fuel) : base(name, fuel, 700)
        {
        }
    }
