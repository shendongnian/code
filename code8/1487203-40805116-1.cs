      // dllhost.exe com+ instances
      foreach (var process in Process.GetProcesses().Where(pr => pr.ProcessName.ToLower() == "dllhost"))
      {
        // better check if 32 bit or 64 bit, in my test I just catch the exception
        try
        {
          MDbgEngine mDbgEngine = new MDbgEngine();
          var dbgProcess = mDbgEngine.Attach(process.Id);
          dbgProcess.Go().WaitOne();
          foreach (MDbgAppDomain appDomain in dbgProcess.AppDomains)
          {
            var corAppDomain = appDomain.CorAppDomain;
            foreach (CorAssembly assembly in corAppDomain.Assemblies)
            {
              if (assembly.Name.ToLower().Contains("tqsoft"))
              {
                dbgProcess.Detach();
                process.Kill();
              }
            }
          }
        }
        catch
        {
          Console.WriteLine("64bit calls not supported from 32bit application.");
        }
      }
