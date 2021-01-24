    public XElement GetAsXml(object obj)
        {
            XElement xelement = new XElement(obj.GetType().Name); 
            PropertyInfo[] props = obj.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object propertyValue = prop.GetValue(obj);
                if(propertyValue != null)
                {
                    XElement xProperty = new XElement(prop.Name, propertyValue);
                    xelement.Add(xProperty);
                }
            }
            return xelement;
        }
