        private List<T> mappingFun<T>( IEnumerable<Dictionary<string, object>> args) where T: Entity
        {
            List<T> listObject = new List<T>();
            
            
            foreach(var arg in args)
            {
                T returnedObject = Activator.CreateInstance<T>();
                PropertyInfo[] modelProperties = returnedObject.GetType().GetProperties();
                var addedobject = listObject.FirstOrDefault(x => x.name == arg[returnedObject.GetType().Name + "_name"].ToString());
                if (addedobject != null)
                {
                    returnedObject = addedobject;
                }
                foreach(var prop in modelProperties)
                {
                    var a = prop.PropertyType;
                    if (prop.PropertyType == typeof(String))
                    {
                        prop.SetValue(returnedObject, arg[returnedObject.GetType().Name + "_" + prop.Name].ToString());
                    }
                    else
                    {
                        if (prop.GetValue(returnedObject) == null)
                        {
                            prop.SetValue(returnedObject, mappingFun<SalesInvoiceItem>(new List<Dictionary<string, object>>() { arg }));
                        }
                        else
                        {
                            ((List<SalesInvoiceItem>)prop.GetValue(returnedObject)).AddRange(mappingFun<SalesInvoiceItem>(new List<Dictionary<string, object>>() { arg }));
                        }
                    }
                }
                
                listObject.Add(returnedObject);
            }
            return listObject;
        }
