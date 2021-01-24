    public class Base {
    
                public Base() {
                    Type type = this.GetType(); // gets current type
                    var props = type.GetProperties(); // get current type's properties
    
                    foreach (var item in props) // B and C
                    {
                        object instance = Activator.CreateInstance(item.PropertyType); // create instace of both B and C
                        item.SetValue(this, instance); // set B property to new value which we have created instance 
    
                    }
    
    
                }
            }
