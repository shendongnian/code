    private static void OnMessageReceived (object sender, MessageReceivedEventArgs e)
            {
                try
                {
                    if (e == null)
                        return;
    
                   (e.CmsData != null)
                   {
                        var data = e.CmsData;
                        //Do something with "data"
                   }
    
                    if (!String.IsNullOrEmpty(e.Message))
                        MessageBox.Show(e.Message); 
                }
               catch (Exception ex)
                {
                //    logger.Error(" Exception " + ex);
                //    throw ex;
                } 
            } 
