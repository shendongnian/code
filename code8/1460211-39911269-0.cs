    class A 
        {
            private static A instance;
    
            private A() { }
    
            public static A Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new A();
                    }
                    return instance;
                }
            }
        }
