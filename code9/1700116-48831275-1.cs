    public class TouchID : ITouchID
    {
        public Task<bool> AuthenticateUserIDWithTouchID()
        {
            var taskSource = new TaskCompletionSource<bool>();            
            var context = new LAContext();
            if (context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out NSError AuthError))
            {
                var replyHandler = new LAContextReplyHandler((success, error) => {
                                            
                    taskSource.SetResult(success);                    
                });
                context.EvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, "Logging with touch ID", replyHandler);
            };
            return taskSource.Task;
        }
    }
