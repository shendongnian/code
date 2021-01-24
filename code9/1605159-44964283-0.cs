                var type = typeof(IfcAlignment);
                List<string> PropertyNames= new List<string>();
                while(type!=null)
                {
                      var properties = type.GetProperties().Where(x => x.DeclaringType == type).Select(x=>x.Name).Reverse().ToList();
                      foreach(string name in properties)
                      {
                           PropertyNames.Add(name);
                      }
                    type = type.BaseType;
                      
                }
                PropertyNames.Reverse();
