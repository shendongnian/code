    public class DerivedThing : BaseThing
    {
        public DerivedThing(string name = "Name", string description = "Description1", decimal cost = 1.0)
        {
            Name = name;
            Description = description;
            Cost = cost;
        }
        public override void MethodThatDoesThings()
        {
            
        }
    }
