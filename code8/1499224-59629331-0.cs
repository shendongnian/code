    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
             this.Policies.SetAllProperties(by => by.Matching(prop => prop.HasAttribute<CustomInjectAttribute>()));
        }
    }
