    try{
       program.Build(null, null, null, IntPtr.Zero);
    }
    catch (Exception ex)
    {
       String buildLog = program.GetBuildLog(context.Devices[0]);
       Console.WriteLine("\n********** Build Log **********\n" + buildLog + "\n*************************");
    }
