    public class AnEntity<T> where T : class, new()
    {
        public T AnEntity(string[] token, ref int i, out TokenEnum tokenEnum,
                                            out string tokenException)
        {
           ...
            PropertyInfo[] properties = typeof(T).GetProperties();
            try
            {
                foreach (PropertyInfo property in properties)
                {
                    ...
                        if (property.Name == "AName") 
                        {
                            break;
                        }
    ...
