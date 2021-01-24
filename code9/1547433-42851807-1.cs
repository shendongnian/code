    DateTime MethodsLastRunTime = DateTime.Now.AddHours(-1);
    ...SomeMethod () 
    {
        if ((DateTime.Now.Hour == 12) && (MethodsLastRunTime < DateTime.Now))
        {
            // Do stuff  
            ....
            ....
            // Flag the method as run for today
            MethodsLastRunTime = DateTime.Now.AddHours(1);  
        }
    }
