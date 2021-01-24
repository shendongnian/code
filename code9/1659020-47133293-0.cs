    foreach(Property info pi in t.GetProperties())
    {
        if(pi.GetCustomAttribute<InsertOnly>() == null)
        {
            //You can safely update this property
        }
        else
        {
            //This property is only for inserting
        }
    }
    
