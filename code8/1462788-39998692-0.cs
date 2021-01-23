    public abstract class BaseClass
    {
        public virtual object FromStream<T>(string line)
        {
            string name, type;
    
            List<PropertyInfo> props = new List<PropertyInfo>(typeof(T).GetProperties()); 
    
            foreach (PropertyInfo prop in props)
            {
                type = prop.PropertyType.ToString();
                name = prop.Name;
    
                Console.WriteLine(name + " as " + type);
            }
            return null;
        }
    }
    
    public class MyClass : BaseClass
    {
        public string id { get; set; }
    
        public string name { get; set; }
    }
