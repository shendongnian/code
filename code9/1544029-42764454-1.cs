    public void Install()
    {
         try
         {
             serviceInstaller1.Install(Dictionary);
             serviceProcessInstaller1.Install(ProcessDictionary);
         }
         catch
         {
         } 
    }
