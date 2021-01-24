        private List<T> mappingFun<T>( IEnumerable<Dictionary<string, object>> args, object propListObj = null) where T: Entity
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
                        var propModuleObj = GetType().GetMethod("mappingFun", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(IEnumerable<Dictionary<string, object>>), typeof(object) }, null).MakeGenericMethod(prop.PropertyType.GetGenericArguments().Single()).Invoke(this, new object[] { new List<Dictionary<string, object>>() { arg }, prop.GetValue(returnedObject) });
                        prop.SetValue(returnedObject, propModuleObj);
                    }
                }
                listObject.AddIfNotExist(returnedObject);
                if(propListObj != null)
                    listObject.AddRange((List<T>)propListObj);
            }
            return listObject;
        }
