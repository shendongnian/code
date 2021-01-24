        //Other Imports...
        using System.Reflection;
 
        public PlaylistBox(ListBox In)
        {
            PropertyInfo[] properties = typeof(ListBox).GetProperties();
            foreach (PropertyInfo p in properties)
                if (p.CanRead && p.CanWrite)
                    p.SetMethod.Invoke(this, new object[] { p.GetMethod.Invoke(In, null) });
        }
