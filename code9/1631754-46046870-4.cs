    using Android.Util;
    
    [assembly: Xamarin.Forms.Dependency(typeof(ViewMethodCallService))]
    namespace SomeProject.UI.Droid
    {    
        public class ViewMethodCallService : Java.Lang.Object, IViewMethodCallService
        {
            public ViewMethodCallService()
            {
                
            }
    
            public void TestMethod()
            {
                Log.Info("Hurrayyyyyyyyyyyyyyyyyyyyyyyyyy", "And I am calling this service");
            }
        }
    }
