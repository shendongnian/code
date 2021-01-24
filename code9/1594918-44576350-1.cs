        class Program
        {
          public K[] ksmall = new K[number];
          static void Main(string[] args)
            {
                 A classAInstance = new A();
                 classAInstance.SomethingElse(ksmall);
            }
        }
    
       class K
        {
            //something
        }
    
        class A
        {
            public void SomethingElse(K[] kSmall)
            {
                    kSmall[1] = new K();
                //do something with ksmall
            }
        }
