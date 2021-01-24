    class Program 
    {
         public static void Main(string[] args)
         {
              Message reply1 = new Message("Bar!");
              Message reply2 = new Message("Hello!");
              reply2.AddReply(new Message("Hello there!");
              Message msg = new Message("Foo!");
              msg.AddReply(reply1);
              msg.AddReply(reply2);
         } 
    }
