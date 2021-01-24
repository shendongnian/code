     PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this, attributes, true);
                return UpdateProperties(props);
            }
             PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this, true);
                return UpdateProperties(props);
            }
             private PropertyDescriptorCollection UpdateProperties(PropertyDescriptorCollection props)
            {
                List<PropertyDescriptor> newProps = new List<PropertyDescriptor>();
                PropertyDescriptor current;
                foreach (PropertyDescriptor prop in props)
                {
                    current = prop;
                    if (prop.Name == "UserPassword")
                        current = TypeDescriptor.CreateProperty(typeof(UserInfo), prop, new Attribute[] { new PasswordPropertyTextAttribute(true) });
                    newProps.Add(current);
                }
                return new PropertyDescriptorCollection(newProps.ToArray()); ;
            }
