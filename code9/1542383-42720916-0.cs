    using Foundation;
    using UIKit;
    using UserNotifications; 
    namespace MyApp_v1.iOS
    {
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //Locator.CurrentMutable.RegisterConstant(new IOSCookieStore(), typeof(IPlatformCookieStore)); //IPlatformCookieStore
            global::Xamarin.Forms.Forms.Init();
            //Notification framework.
            //----------------------
		UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound, (approved, err) => {
                // Handle approval
            });
            //Get current notification settings.
            UNUserNotificationCenter.Current.GetNotificationSettings((settings) => {
                var alertsAllowed = (settings.AlertSetting == UNNotificationSetting.Enabled);
            });
            UNUserNotificationCenter.Current.Delegate = new AppDelegates.UserNotificationCenterDelegate();
            //----------------------
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
    }
