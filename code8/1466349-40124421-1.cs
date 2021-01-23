    var property = typeof(MyClassDto).GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(t => t.CanRead && t.CanWrite);
                foreach (var item in property)
                {
                    string propertyName = item.Name;
                    bool CompilerGenerated = item.GetGetMethod()
                          .GetCustomAttributes(typeof(CompilerGeneratedAttribute), true).Any();
                    //Description is not CompilerGeneratedAttribute so return false; 
                }
