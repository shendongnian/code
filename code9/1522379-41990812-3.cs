    public abstract class A 
    {
        public string Text { get; set; }
    
        public string SayHello() => "hello world!";
    }
    
    public class AStore
    {
         private class AInternal : A {}
    
         public void DoStuff()
         {
             A a = new AInternal();
             a.Text = "whatever";
             string helloText = a.SayHello();
         }
    }
      
