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
      Console.WriteLine("printStuff 1");
      Console.WriteLine("printStuff 2");
      Console.WriteLine("printStuff 3");
      Console.WriteLine("printStuff 4");
      Console.WriteLine("printStuff 5");
      Console.WriteLine("printStuff 6");
    }
