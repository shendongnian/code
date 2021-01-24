    public class Foo
    {
         public Bar Bar
         {
             get
             {
                 return new Bar();
             }
         } 
    }
    public class Bar
    {
         public Foo Foo
         {
             get
             {
                 return new Foo();
             }
         } 
    }
