    enum StartFormLayouts
    {
        DefaultDevice0,
        AppRoot0,
        Other,        
    }
    // class that specifies the layout of any startform
    class AppJobs
    {
        private bool IsAppRoot0 
        {
            get{return Appjobs.AppRoot == null || Appjobs.AppRoot == "0";}
        }
        private bool IsDefaultDevice0
        {
            get{return Appjobs.DefaultDevice == null || Appjobs.DefaultDevice == "0";}
        }
        public StartFormLayoug GetPreferredLayout()
        {
             if (this.IsAppRoot0)
             {
                 if (this.IsDefaultDevice)
                 {
                      return StartFormLayout.DefaultDevice0;
                 }
                 else
                      return StartFormLayout.AppRoot0;
              }
              else
              {
                  return StartFormLayout.Other;
              }
        }
        public bool ShouldAskDirectoryCreation()
        {
            return (!this.IsAppRoot0 && !Directory.Exists(AppRoot));
        }
    }
