    PropertyInfo[] properties = ctr.GetType().GetProperties();
        foreach (PropertyInfo property in properties)
        {
            Console.Write(property.Name + ":\t");
            Console.WriteLine(property.GetValue(ctr).ToString());
        }
