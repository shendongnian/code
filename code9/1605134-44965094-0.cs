    public static class PropertyExtensions
    {
        public static ModelWrapper<T> Wrap<T>(this T property)
        {
            var genericType = typeof(ModelWrapper<>);
            var specificType = genericType.MakeGenericType(typeof(T));
    
            var wrappedPropertyModel = (ModelWrapper<T>)Activator.CreateInstance(specificType);
            wrappedPropertyModel.ModelProperty = property;
    
            return wrappedPropertyModel;
        }
    }
    
    public class ModelWrapper<T>
    {
        public T ModelProperty { get; set; }
    }
