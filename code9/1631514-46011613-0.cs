     public delegate void dele();
     public static event dele anEvent;
      static void Main(string[] args) {
          List<dele> list = new List<dele>();
          list.Add(anEvent);
          list[0] += Dele;
          list[0].Invoke(); //this actually gets invoked and does not throw!
          anEvent = list[0];
          Console.WriteLine(anEvent == null); //the output is false
      }
    private static void Dele() {
      Console.WriteLine("Beep"); // this gets printed after invoking the event
    }
