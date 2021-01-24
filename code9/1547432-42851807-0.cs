    DateTime MethodsLastRunTime = DateTime.Now.AddDays(-1);
    ...SomeMethod () 
    {
        if ((DateTime.Now.Hour == 12) && (MethodsLastRunTime < DateTime.Now))
        {
            // Do stuff  
            MethodsLastRunTime = DateTime.Now.AddHours(1);  
        }
    }
