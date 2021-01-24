    public class DynamicPropertyDescriptor : PropertyDescriptor
    {
        private Type ObjectType;
        private PropertyInfo Property;
        public DynamicPropertyDescriptor(string name, params Type[] objectType) : base(name, null)
        {
            ObjectType = objectType[0];
            foreach (var t in objectType)
            {
                Property = t.GetProperty(name);
                if (Property != null)
                {
                    break;
                }
            }
        }
        public override object GetValue(object component)
        {
            var prop = component.GetType().GetProperty(Name);
            if (prop != null)
            {
                return prop.GetValue(component);
            }
            DynamicObject obj = component as DynamicObject;
            if (obj != null)
            {
                var binder = new MyGetMemberBinder(Name);
                object value;
                obj.TryGetMember(binder, out value);
                return value;
            }
            return null;
        }
        public override void SetValue(object component, object value)
        {
            var prop = component.GetType().GetProperty(Name);
            if (prop != null)
            {
                prop.SetValue(component, value);
            }
            DynamicObject obj = component as DynamicObject;
            if (obj != null)
            {
                var binder = new MySetMemberBinder(Name);
                obj.TrySetMember(binder, value);
            }
        }
        public override Type PropertyType
        {
            get { return Property.PropertyType; }
        }
        public override bool IsReadOnly
        {
            get { return !Property.CanWrite; }
        }
        public override bool CanResetValue(object component)
        {
            return false;
        }
        public override Type ComponentType
        {
            get { return typeof(object); }
        }
        public override void ResetValue(object component)
        {
        }
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
    public class MyGetMemberBinder : GetMemberBinder
    {
        public MyGetMemberBinder(string name)
            : base(name, false)
        {
        }
        public override DynamicMetaObject FallbackGetMember(DynamicMetaObject target, DynamicMetaObject errorSuggestion)
        {
            throw new NotImplementedException();
        }
    }
    public class MySetMemberBinder : SetMemberBinder
    {
        public MySetMemberBinder(string name)
            : base(name, false)
        {
        }
        public override DynamicMetaObject FallbackSetMember(DynamicMetaObject target, DynamicMetaObject value, DynamicMetaObject errorSuggestion)
        {
            throw new NotImplementedException();
        }
    }
