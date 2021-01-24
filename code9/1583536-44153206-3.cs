    string filename = "C:\\darkmailWindows\\darkmailwindows\\Dependencies\\ManagedLibDarkMail\\Lib\\ManagedLibDarkClient.dll";
    Assembly asm = Assembly.LoadFrom(filename);
    foreach (Type t in asm.GetTypes())
    {
       if (t.GetInterfaces().Contains(typeof(IAccountHandler)))
       {
          try
          {
             IAccountHandler instance = (IAccountHandler)Activator.CreateInstance(t);
             if (instance != null)
             {
                 instance.RegisterAccnt(e.AccntInfo.AccntName, e.AccntInfo.AuthCode);                   
             }
           }
           catch(Exception ex)
           {
              //manage exception
           }
        }
     }
