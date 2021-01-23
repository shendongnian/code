    Parallel.For(0,2,i=>{
      int local = i;
      if(local=0)
         Process.GetCurrentProcess().ProcessorAffinity = (System.IntPtr)(255);
    
      if(local==1)
         Process.GetCurrentProcess().ProcessorAffinity = (System.IntPtr)(254);
      Thread.Sleep(25);// to make sure  both set their affinities
      Console.WriteLine(Process.GetCurrentProcess().ProcessorAffinity);
    });
