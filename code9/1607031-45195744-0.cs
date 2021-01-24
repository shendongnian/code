    public class RequestAddedAppMonitorHandler : IHandler<RequestAdded>
    {
        public async Task Handle(RequestAdded args)
        {
            try
            {
                GoogleNotification notification = CreateAndroidPartnerAppNotification(deviceId);
    
                // this statment is executed, and the text log file will contains this line
                TracingSystem.TraceInformation("Before Send Google Notification");  
    
                await SendersFacade.PartnerSender.Send(notification);
            }
            catch (Exception ex)
            {
                TracingSystem.TraceException(ex);
            }
        }
    }
