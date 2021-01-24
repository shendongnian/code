    public class SomeClass
    {
       public event EventHandler Event1;
       public event EventHandler Event2;
    
       public SomeClass()
       {
          Event1 += Subscriber1;
          Event1 += Subscriber2;
    
          var subscribers = Event1.GetInvocationList();
    
          if(subscribers != null)
          {
             foreach(var subscriber in subscribers)
             {
                EventHandler realSubscriber = (EventHandler)subscriber;
                Event2 += realSubscriber;
             }
          }
    
          Event1(this, EventArgs.Empty);
          Event2(this, EventArgs.Empty);
       }
    
       public void Subscriber1(object sender, EventArgs e)
       {
          Console.WriteLine("Subscriber 1 invoked");
       }
    
       public void Subscriber2(object sender, EventArgs e)
       {
          Console.WriteLine("Subscriber 2 invoked");
       }
    }
