    [Service, IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class FCMInstanceIdService : FirebaseInstanceIdService
    {
       // private string LogTag = "FCMInstanceIdService";
        public override void OnTokenRefresh()
        {
            var fcmDeviceId = FirebaseInstanceId.Instance.Token;
            // Settings (is Shared Preferences) - I save the FCMToken Id in shared preferences 
           // if FCMTokenId is not the same as old Token then update on the server
            if (Settings.FcmTokenId != fcmDeviceId)
            {
                var oldFcmId = Settings.FcmTokenId;
                var validationContainer = new ValidationContainer();
                // HERE UPDATE THE TOKEN ON THE SERVER
                TBApp.Current._usersProvider.UpdateFcmTokenOnServer(oldFcmId, fcmDeviceId, validationContainer);
                Settings.FcmTokenId = fcmDeviceId;
            }
            base.OnTokenRefresh();
        }
    }
