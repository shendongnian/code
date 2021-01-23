    using System;
    using WebSocketSharp;
    
    namespace Example
    {
      public class Program
      {
        public static void Main (string[] args)
        {
          using (var ws = new WebSocket ("ws://YOUR_URI_HERE")) {
            ws.OnMessage += (sender, e) =>
                Console.WriteLine ("It's ok I got my answer back : " + e.Data);
    
            ws.Connect ();
            ws.Send ("COMMAND FOR THE SERVER");
            Console.ReadKey (true);
          }
        }
      }
    }
  
