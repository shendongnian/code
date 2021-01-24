    public class MyPropertyDescriptor: PropertyDescriptor
        {
            
            MyProperty _prop;
            object _parent;
            public MyPropertyDescriptor(MyProperty prop, object parent)
              : base(prop.PropertyName, null)
            {
                _prop = prop;
                _parent = parent;
            }
    
            public override AttributeCollection Attributes
            {
                get
                {
                    var attributes = TypeDescriptor.GetAttributes(GetValue(null), false);
    
                    return attributes;
                }
            }
    
            public override bool CanResetValue(object component)
            {
                return false;
            }
    
            public override object GetValue(object component)
            {
                switch (_prop.Type)
                {
                    case MyProperty.PropertyType.String:
                        return _prop.StringValue;
                    case MyProperty.PropertyType.Number:
                        return _prop.NumberValue;
                    default:
                        break;
                }
                return null;
            }
            
            
    
            public override void ResetValue(object component)
            {
                throw new NotImplementedException();
            }
    
            public override void SetValue(object component, object value)
            {
                switch (_prop.Type)
                {
                    case MyProperty.PropertyType.String:
                        _prop.StringValue = value as string;
                        break;
                    case MyProperty.PropertyType.Number:
                        _prop.NumberValue = (double)value;
                        break;
                    default:
                        break;
                }
            }
    
            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
    
            public override Type ComponentType
              => _parent.GetType();
    
            public override bool IsReadOnly
              => false;
    
            public override Type PropertyType
            {
                get
                {
                    switch (_prop.Type)
                    {
                        case MyProperty.PropertyType.String:
                            return _prop.StringValue.GetType();
                        case MyProperty.PropertyType.Number:
                            return _prop.NumberValue.GetType();
                        default:
                            return typeof(string);
                    }
                }
            }
        }
