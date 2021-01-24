    //add appropriate using declarations
    [assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
    namespace <YourApp>.Droid
    {
        public class AndroidMethods : IAndroidMethods
        {
            public void startPhoneCall(string number)
            {
                var phoneDialer = CrossMessaging.Current.PhoneDialer;
                if (phoneDialer.CanMakePhoneCall)
                {
                    phoneDialer.MakePhoneCall(number);
                }
            }
        }
    }
