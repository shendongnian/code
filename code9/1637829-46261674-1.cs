    public class Foo
    {
         public Bar Bar
         {
             get
             {
                 //EF would load this from cache, if alrady exists
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
                 //EF would load this from cache, if alrady exists
                 return new Foo();
             }
         } 
    }
