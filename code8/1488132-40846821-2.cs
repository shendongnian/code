    static void Main(string[] args)
    {
      Console.WriteLine("Start Of Main - output not redirected yet!");
      FileStream fs = new FileStream("ScreenRecord.txt", FileMode.Create);
      // First, save the standard output.
      TextWriter tmp = Console.Out;
      StreamWriter sw = new StreamWriter(fs);
      Console.SetOut(sw);
      Console.WriteLine("this writes to file 1");
      printStuff();
      Console.SetOut(tmp);
      Console.WriteLine("this line not in file");
      Console.ReadKey();
      sw.Close();
    }
    private static void printStuff()
    {
      for (int i = 1; i < 7; i++)
        Console.WriteLine("printStuff " + i);
    }
