    LomontFFT LFFT = new LomontFFT();
    LFFT.RealFFT(data, true);
    System.Console.WriteLine("{0}", Math.Abs(data[0]);
    for (int i = 1; i < data.Length/2; i++)
    {
      System.Console.WriteLine("{0}",
        Math.Sqrt(data[2*i]*data[2*i]+data[2*i+1]*data[2*i+1]));
    }
    System.Console.WriteLine("{0}", Math.Abs(data[1]);
