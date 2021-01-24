    public static class PropertyExtensions
    {
        public static ModelWrapper<T> Wrap<T>(this T property, string propertyName)
        {
            var genericType = typeof(ModelWrapper<>);
            var specificType = genericType.MakeGenericType(typeof(T));
            var wrappedPropertyModel = (ModelWrapper<T>)Activator.CreateInstance(specificType);
            wrappedPropertyModel.ModelProperty = property;
            wrappedPropertyModel.PropertyName = propertyName;
            return wrappedPropertyModel;
        }
    }
    
    public class ModelWrapper<T>
    {
        public string PropertyName { get; set; }
        public T ModelProperty { get; set; }
    }
