        class abc
        {
            public static string connection_string = "your connection string";
        }
        class xyz
        {
            public string connection_string()
            {
                return "your connection string";
            }
        }
        class webpage // call here at any page
        {
            // by using variable
            string con_string = abc.connection_string;
    
            //by using function
            xyz obj_ = new xyz();
            string con_string1 = obj_.connection_string();
        }
