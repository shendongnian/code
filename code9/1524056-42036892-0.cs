    public static class Myclass
        {
            public static class M1
            {
                //Here How can I call m2
                public static void A1()
                {
                    var m2 = new Myclass.m2(); // create m2instance
                    m2.A2(); // call m2
                }
            }
            public class m2
            {
                //Here How can I call m1
                public void A2()
                {
                    Myclass.M1.A1(); // called M1.A1
                }
    
            }
        }
