    public partial class QuayService : ServiceBase
        {
            OrderJobSchedule scheduler;
            public QuayService()
            {
                InitializeComponent();
            }
            protected override void OnStart(string[] args)
            {
                try
                {
                    scheduler = new OrderJobSchedule();
                    scheduler.Start();
    
                    SendEmail("(Shopify)Quay Service Started",
                        "(Shopify)Quay Service Successfuly Started");
                }
                catch (Exception ex)
                {
                    ProcessException(ex, "Error starting (Shopify)Quay Service");
                    EventLog.WriteEntry("Error starting (Shopify)Quay service and timer..." + ex.Message);
                }
            }
            protected override void OnStop()
            {
                try
                {
                    if (scheduler != null)
                    {
                        scheduler.Stop();
                    }
    
                    SendEmail("(Shopify)Quay Service stopped",
                        "(Shopify)Quay Service Successfuly Stopped");
                }
                catch (Exception ex)
                {
                    ProcessException(ex, "Error stopping (Shopify)Quay Service");
                    EventLog.WriteEntry("Error stopping (Shopify)Quay timer and service..." + ex.Message);
                }
            }
            private void SendEmail(string subject, string body)
            {
                new Email().SendErrorEmail("Quay", subject, body);
            }
            private void ProcessException(Exception ex,
                string customMessage)
            {
                var innerException = "";
                if (ex.InnerException != null)
                    innerException = (!string.IsNullOrWhiteSpace(ex.InnerException.Message)) ? ex.InnerException.Message : "";
    
    
                new Email().SendErrorEmail("Quay", customMessage, 
                    ex.Message + " " + innerException);
            }
        } 
