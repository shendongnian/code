    LomontFFT LFFT = new LomontFFT();
    LFFT.RealFFT(data, true);
    System.Console.WriteLine("{0}", Math.Abs(buffer[0]);
    for (int i = 1; i < data.Length/2; i++)
    {
      System.Console.WriteLine("{0}",
        Math.Sqrt(buffer[2*i]*buffer[2*i]+buffer[2*i+1]*buffer[2*i+1]));
    }
    System.Console.WriteLine("{0}", Math.Abs(buffer[1]);
