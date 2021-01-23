    foreach (var prop in myObject.GetType().GetProperties())
                {
                    var attribute = Attribute.GetCustomAttribute(prop, typeof(XmlElementAttribute)) as XmlElementAttribute;
                        XmlElementAttribute myElementAttribute = new XmlElementAttribute();
                        XmlAttributes myAttributes = new XmlAttributes();
                        if (attribute==null||attribute.ElementName.IsNullOrEmpty())
                        {
                            myElementAttribute.ElementName = prop.Name.NameToUpper();
                        }
                        if (prop.PropertyType == typeof(string))
                        {
                            myElementAttribute.IsNullable = true;
                        }
                        myAttributes.XmlElements.Add(myElementAttribute);
                        myOverrides.Add(typeof(myObject), prop.Name, myAttributes);
           }
