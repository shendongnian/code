    public class EntitiesContainer
    {
        public List<Address> Addresses { get; set; }
        public List<Person> People { get; set; }
        public List<Contract> Contracts { get; set; }
        public EntitiesContainer()
        {
            var propertyInfo = this.GetType().GetProperties();
            foreach (var property in propertyInfo)
            {
                property.SetValue(this, Activator.CreateInstance(property.PropertyType));
            }
        }
    }
