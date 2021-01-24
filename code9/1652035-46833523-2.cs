    using Android.App;
    using Android.Content;
    
    namespace XXX.Droid.LocalNotifications
    {
    	[BroadcastReceiver(Enabled = true)]
    	[IntentFilter(new[] { "android.intent.action.BOOT_COMPLETED" })]
    	public class CalendarReceiver: BroadcastReceiver
    	{
    		#region implemented abstract members of BroadcastReceiver
    
    		public override void OnReceive (Context context, Intent intent)
    		{
    			var notificationUID = intent.Action;
    			var title = intent.GetStringExtra ("Title");
    			var message = intent.GetStringExtra ("Message");
    
    			Intent service1 = new Intent(context, typeof(CalendarAlarmService));
    			service1.SetData(Android.Net.Uri.Parse("custom://" + notificationUID));
    			service1.SetAction(notificationUID);
    			service1.PutExtra("Title", title);
    			service1.PutExtra("Message", message);
    			context.StartService(service1);
    
    			if (MainActivity.AppIsInForground(context))
    			{
    				// App is in Foreground
    				GlobalMethods.RecibioNotificacionLocal(intent.Action);
    			}
    			else {
    				// App is in Background
    				//App.CrearNotificacionSQL(intent.Action);
    			}
    
    			App.Instance.ShowNotification(title, message);
    			//Toast.MakeText(Forms.Context, message ,ToastLength.Long).Show();
    
    		}
    
    
    
    		#endregion
    
    		public CalendarReceiver ()
    		{
    		}
    	}
    }
