    public void ExtractDataFromSharePoint()
    {
       try
       {
         Library.WriteErrorLog("inside task");    
         ArchiveAdministration admin = new ArchiveAdministration();
         admin.ArchiveAuto();
         Library.WriteErrorLog("job completed");
         _timer.Stop();
       }
       catch(Exception ex)
       {
         Library.WriteErrorLog(ex.Message); //or try to log the stacktrace also    
       }    
    }
