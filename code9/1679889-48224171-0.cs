    private void PrintStackTrace()
    {
      var st = new StackTrace();
      foreach (var sf in st.GetFrames())
        Console.WriteLine($"{sf.GetMethod().DeclaringType.Assembly.GetName().Name} {sf.GetMethod().DeclaringType.Name} {sf.GetMethod().Name}");
    }
