    public class DictionaryAdapter : ICustomTypeDescriptor
    {
        IDictionary dictionary;
        public DictionaryAdapter(IDictionary d)
        {
            dictionary = d;
        }
        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }
        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }
        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }
        EventDescriptorCollection System.ComponentModel.ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return dictionary;
        }
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }
        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }
        PropertyDescriptorCollection 
            System.ComponentModel.ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[] { });
        }
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            ArrayList properties = new ArrayList();
            foreach (DictionaryEntry e in dictionary)
            {
                properties.Add(new DictionaryPropertyDescriptor(dictionary, 
                    e.Key.ToString()));
            }
            PropertyDescriptor[] props = 
                (PropertyDescriptor[])properties.ToArray(typeof(PropertyDescriptor));
            return new PropertyDescriptorCollection(props);
        }
    }
    public class DictionaryPropertyDescriptor : PropertyDescriptor
    {
        IDictionary dictionary;
        string key;
        internal DictionaryPropertyDescriptor(IDictionary d, string k)
            : base(k.ToString(), null)
        {
            dictionary = d;
            key = k;
        }
        public override Type PropertyType
        {
            get { return dictionary[key].GetType(); }
        }
        public override void SetValue(object component, object value)
        {
            dictionary[key] = value;
        }
        public override object GetValue(object component)
        {
            return dictionary[key];
        }
        public override bool IsReadOnly
        {
            get { return false; }
        }
        public override Type ComponentType
        {
            get { return null; }
        }
        public override bool CanResetValue(object component)
        {
            return false;
        }
        public override void ResetValue(object component)
        {
        }
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
