    internal class MyFactory
    {
        internal object CreateItem1() { return ...; }
        internal object CreateItem2() { return ...; }
        internal object CreateItem2(ExampleEnum e) 
        {
            switch(e) 
            {
                case e.Something:
                   return new blah();
                default:
                   return new List<string>();
            }
        }
        
    }
