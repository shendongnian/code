    public static void Main()
    {
         MyListener listener = new MyListener();
         Debug.Listeners.Add(listener);
         
         // this ends up in MyListener.WriteLine, but only in a debug version
         Debug.WriteLine("This is a debug log message");
         Debug.Listeners.Remove(listener);
    }
