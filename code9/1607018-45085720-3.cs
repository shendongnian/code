    public class RequestAddedAppMonitorHandler : IHandler<RequestAdded> {
        public async Task Handle(RequestAdded args) {
            try {
                string deviceId = args.DeviceId;//This is an assumption here
                var notification = CreateAndroidPartnerAppNotification(deviceId);
                // this statment is executed, and the text log file will contains this line
                TracingSystem.TraceInformation("Before Send Google Notification");
                await SendersFacade.PartnerSender.SendAsync(notification);
            } catch (Exception ex) {
                TracingSystem.TraceException(ex);
            }
        }
        private GoogleNotification CreateAndroidPartnerAppNotification(string to) {
            // some initialization and creating for the notification object.
            return new GoogleNotification() {
                To = to
            };
        }
    }
