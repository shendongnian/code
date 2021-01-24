    private void j_OnAuthenticate(object sender)
    {
       try
       {
           JabberClient j = (JabberClient)sender;
           ...
       }
       catch (Exception ex)
       {
           WriteToFile("Simple Service Error on: {0} " + ex.Message + ex.StackTrace);
           //Stop the Windows Service.
           using (System.ServiceProcess.ServiceController serviceController = new System.ServiceProcess.ServiceController("SparkBirthDayGreeting"))
           {
                serviceController.Stop();
           }
       }
