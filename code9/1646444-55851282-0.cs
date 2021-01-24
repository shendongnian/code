csharp
[Activity(LaunchMode = LaunchMode.SingleTop, ...)]
public class MainActivity : MvxAppCompatActivity
Generate the notification PendingIntent like this:
csharp
var intent = new Intent(Context, typeof(MainActivity));
intent.AddFlags(ActivityFlags.SingleTop);
// Putting an extra in the Intent to pass data to the MainActivity
intent.PutExtra("from_notification", true);
var pendingIntent = PendingIntent.GetActivity(Context, notificationId, intent, 0);
Now there are two places to handle this Intent from MainActivity while still allowing the use of MvvmCross navigation service:
If the app was not running while the notification was clicked then `OnCreate` will be called.
csharp
protected override void OnCreate(Bundle bundle)
{
    base.OnCreate(bundle);
    if (bundle == null && Intent.HasExtra("from_notification"))
    {
        // The notification was clicked while the app was not running. 
        // Calling MvxNavigationService multiple times in a row here won't always work as expected. Use a Task.Delay(), Handler.Post(), or even an MvvmCross custom presentation hint to make it work as needed.
    }
}
If the app was running while the notification was clicked then `OnNewIntent` will be called.
csharp
protected override void OnNewIntent(Intent intent)
{
    base.OnNewIntent(intent);
    if (intent.HasExtra("from_notification"))
    {
        // The notification was clicked while the app was already running.
        // Back stack is already setup.
        // Show a new fragment using MvxNavigationService.
    }
}
