    public int MethodToCheckNotNull(ViewModel obj)
    {
            int i = 0;
            PropertyInfo[] properties = typeof(obj).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(obj) != null)
                {
                    i++;
                }
            }
            return i;
     }
