	public class MessageBox
	{
		public enum MessageBoxResult
		{
			Positive, Negative, Ignore, Cancel, Closed
		};
		private static MessageBoxResult yesNoDialogResult;
		public static async Task<MessageBoxResult> Show(Context context, String title, String message, String positiveMessage, String negativeMessage)
		{
			yesNoDialogResult = MessageBoxResult.Closed;
			var alert = new AlertDialog.Builder(context)
               .SetTitle(title).SetMessage(message)
               .SetCancelable(false)
               .SetIcon(Android.Resource.Drawable.IcDialogAlert);
			var waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
			alert.SetPositiveButton("OK", (senderAlert, args) =>
			{
				yesNoDialogResult = MessageBoxResult.Positive;
				waitHandle.Set();
			});
			alert.SetNegativeButton("Cancel", (senderAlert, args) =>
			{
				yesNoDialogResult = MessageBoxResult.Negative;
				waitHandle.Set();
			});
			alert.Show();
			await Task.Run(() => waitHandle.WaitOne());
			return yesNoDialogResult;
		}
	}
