    public abstract class BaseItem {
        static Dictionary<string, PropertyInfo> _attributes = null;
    
        public BaseItem() {
            if ( _attributes == null ) { 
                InitializeProperties(); 
            }
        }
        void InitializeProperties() {
            _attributes = new Dictionary<string, PropertyInfo>()
            var properties = typeof(BaseItem).GetProperties().Where( property => Attribute.IsDefined(property, typeof(ItemAttributeAttribute)));
            foreach(var property in properties) {
                string name = ((ItemAttributeAttribute)property.GetCustomAttribute(property, typeof(ItemAttributeAttribute))).AttributeName;
                _attributes.Add(name, property);
            }
        }
    }
