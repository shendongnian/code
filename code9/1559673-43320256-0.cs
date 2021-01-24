    object obj = this.SelectedObject;
    Type type = obj.GetType();
    PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
    foreach(PropertyInfo pInfo in props)
    {
        if (pInfo.CanWrite)
        { 
               // mark as read/write
        }
        else
        {
             // mark as read-only
        }
    }
