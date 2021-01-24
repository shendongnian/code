    public class ToastService : IToastService
	{
        private readonly IMvxAndroidCurrentTopActivity _topActivity;
        public ToastService(IMvxAndroidCurrentTopActivity topActivity)
        {
            _topActivity = topActivity;
        }
		
		public void ShowToast(string message)
		{
		    Toast.MakeText(activity.ApplicationContext, message, ToastLength.Short).Show();
		}
	}
