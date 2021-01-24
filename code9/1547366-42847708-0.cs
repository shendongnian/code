        public class PrivateClass
        {
            //Only from inside this class:
            private PrivateClass()
            {
            }
            public static PrivateClass GetPrivateClass()
            {
                //This calls the private constructor so you can control exactly what happens
                return new PrivateClass();
            }
        
        }
