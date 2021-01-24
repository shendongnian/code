     public delegate void dele();
     public static event dele anEvent;
      static void Main(string[] args) {
          List<dele> list = new List<dele>();
          list.Add(anEvent);
          list[0] += Dele;
          list[0].Invoke(); //this actually gets invoked and does not throw!
          anEvent = list[0];
          Console.WriteLine(anEvent == null); //the output is false
          anEvent.Invoke(); // this also gets s invoked and does not throw
      }
    private static void Dele() { //this gets invoked 2 times as expected
      Console.WriteLine("Beep"); // this gets printed after invoking the event
    }
