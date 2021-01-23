    namespace MyNamespace
    {
        public class MyClass
        {
            public static void Method(MyClass c = null)
            {
                if (c == null)
                {
                    //Do Stuff From Static
                }
                else
                {
                    //Do Different Stuff With Instance
                }
            }  
  
            public void Method()
            {
                Method(this);
            }
        }
    }
