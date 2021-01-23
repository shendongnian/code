    public static class PropertyHelper
    {
        public static IPropertyAccessor CreateAccessor(PropertyInfo propertyInfo)
        {
	        if (propertyInfo == null)
    	        throw new ArgumentNullException("propertyInfo");
    
            return (IPropertyAccessor)Activator.CreateInstance(
                typeof(PropertyWrapper<,>).MakeGenericType
                    (propertyInfo.DeclaringType, propertyInfo.PropertyType), propertyInfo);
        }
    }
    public interface IPropertyValueAccessor
    {
        PropertyInfo PropertyInfo { get; }
        string Name { get; }
        object GetValue(object source);
    }
    public interface IPropertyAccessor
    {
        PropertyInfo PropertyInfo { get; }
        string Name { get; }
        object GetValue(object source);
        void SetValue(object source, object value);
    }
    internal class PropertyWrapper<TObject, TValue> : IPropertyAccessor
    {
        private PropertyInfo _propertyInfo;
        private Func<TObject, TValue> _getMethod;
        private Action<TObject, TValue> _setMethod;
        /// <summary>
        /// Constructeur public
        /// </summary>
        /// <param name="propertyInfo">la propriété à encapsulé
        public PropertyWrapper(PropertyInfo propertyInfo)
        {
            _propertyInfo = propertyInfo;
            MethodInfo mGet = propertyInfo.GetGetMethod(true);
            MethodInfo mSet = propertyInfo.GetSetMethod(true);
             // Rq : on peut par se biais acceder aussi aux accesseur privé
            //      tous les aspects liés à la sécurité est donc pris en charge par CreateDelegate
            //      et non à chaque appel à GetMethod/SetMethod
            _getMethod = (Func<TObject, TValue>)Delegate.CreateDelegate
                    (typeof(Func<TObject, TValue>), mGet);
            _setMethod = (Action<TObject, TValue>)Delegate.CreateDelegate
                    (typeof(Action<TObject, TValue>), mSet);
        }
        object IPropertyValueAccessor.GetValue(object source)
        {
            return _getMethod((TObject)source);
        }
        void IPropertyAccessor.SetValue(object source, object value)
        {
            _setMethod((TObject)source, (TValue)value);
        }
        /// <summary>
        /// Voir <see cref="IPropertyAccessor.Name">
        /// </see></summary>
        public string Name
        {
            get
            {
                return _propertyInfo.Name;
            }
        }
        /// <summary>
        /// Voir <see cref="IPropertyAccessor.PropertyInfo">
        /// </see></summary>
        public PropertyInfo PropertyInfo
        {
            get
            {
                return _propertyInfo;
            }
        }
    }
