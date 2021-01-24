    public class ModelFactory
    {
        private IDictionary<string, PropertyInfo> propertiesInfo { get; set; }
        public ModelFactory()
        {
            this.propertiesInfo = typeof(Model)
                                .GetProperties()
                                .ToDictionary(p => p.Name, p => p);
        }
        public Model Create(string[] propertiesToInitialize, dynamic value)
        {
            var model = new Model();
            foreach (var propertyName in propertiesToInitialize)
            {
                if (this.propertiesInfo.ContainsKey(propertyName))
                {
                    var property = this.propertiesInfo[propertyName];
                    property.SetValue(model, value);
                }
            }
            return model;
        }
    }
