    using System;
    using LibBcm2835.Net;
    namespace ForceSeer2
    {
        public class ADS1256
        {       
            public ADS1256()
            {
            }
            private static Bcm2835 instance;
            private static object syncRoot = new Object();
            public static Bcm2835 Instance
            {
                get
                {
                    if(instance == null)
                    {
                        lock(syncRoot)
                        {
                            if(instance == null)
                                instance = new Bcm2835();
                        }
                    }
                    return instance;
                }
            }
            //example of a method in this class that uses a method from the class 
            //Bcm2835:
            public static int initializeSPI ()
            {
                 //Your method implementation here
            }
            //Other class members here
        }
    }
