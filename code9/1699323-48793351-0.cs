    public class Example
    {
         // Variable declared as a class global.
         private readonly Sample sample; 
    
         // Constructor to build our sample.
         public Example() => sample = new Sample(); 
         // Button writing a property from sample.
         protected void btnSend(object sender, EventArgs e) => Console.WriteLine(sample.SomeProperty); 
    }
