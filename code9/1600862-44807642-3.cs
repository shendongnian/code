    [Activity(LaunchMode = LaunchMode.SingleTop, ....)]
    public class MainActivity : FormsApplicationActivity {
        protected override void OnNewIntent(Intent intent) {
            if(intent.HasExtra("SomeSpecialKey")) {
                System.Diagnostics.Debug.WriteLine("\nIn MainActivity.OnNewIntent() - Intent Extras: " + intent.GetStringExtra("SomeSpecialKey") + "\n");
            }
            base.OnNewIntent(intent);
        }
