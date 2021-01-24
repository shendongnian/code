    using System;
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Support.V7.App;
    
    namespace XXX.Droid.LocalNotifications
    {
    	[Service(Enabled = true)]
    	public class CalendarAlarmService : Service
    	{
    		ServiceBinder binder;
    		NotificationManager mManager;
    
    		public override IBinder OnBind (Intent intent)
    		{
    			binder = new ServiceBinder(this);
    			return binder;
    		}
    
    		public override void OnCreate ()
    		{
    			base.OnCreate ();
    		}
    
    		public override void OnDestroy ()
    		{
    			base.OnDestroy ();
    		}
    
    		#region implemented abstract members of Service
    
    		public override StartCommandResult OnStartCommand (Intent intent, StartCommandFlags flags, int startId)
    		{
    			var notificationUID = intent == null ? string.Empty : intent.Action;
    			var title = intent.GetStringExtra("Title");
    			var message = intent.GetStringExtra("Message");
    
    			if (ApplicationContext == null || this == null)
    			{
    #if DEBUG
    				Console.WriteLine("CalendarAlarmService - OnStartCommand - ApplicationContext == null!");
    				return StartCommandResult.Sticky;
    #endif
    			}
    
    			if (!MainActivity.AppIsInForground(this))
    			{
    				mManager = (NotificationManager)GetSystemService(NotificationService);
    				Intent mainActivityIntent = new Intent(this, typeof(MainActivity));
    				mainActivityIntent.SetAction(notificationUID);
    				mainActivityIntent.PutExtra("Title", title);
    				mainActivityIntent.PutExtra("Message", message);
    				mainActivityIntent.PutExtra("Notification", notificationUID);
    				mainActivityIntent.SetFlags(ActivityFlags.SingleTop);
    
    				Notification notification =
    					new Notification(Resource.Drawable.icon, "Notificacion", Java.Lang.JavaSystem.CurrentTimeMillis());
    				notification.Defaults |= NotificationDefaults.Sound;
    				mainActivityIntent.AddFlags(ActivityFlags.SingleTop | ActivityFlags.ClearTop);
    
    				PendingIntent pendingNotificationIntent =
    					PendingIntent.GetActivity(this, 0, mainActivityIntent, PendingIntentFlags.UpdateCurrent);
    
    				notification.Flags |= NotificationFlags.AutoCancel;
    
    				NotificationCompat.Builder builder = new NotificationCompat.Builder(
    							this);
    				notification = builder.SetContentIntent(pendingNotificationIntent)
    									  .SetSmallIcon(Resource.Drawable.icon).SetWhen(DateTime.Now.Ticks)
    									  .SetAutoCancel(true).SetContentTitle(title)
    									  .SetDefaults((int)NotificationDefaults.Sound)
    									  //.SetVibrate()
    									  .SetContentText(message).Build();
    
    				if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(message))
    				{
    					mManager.Notify(0, notification);
    				}
    			}
    
    			return base.OnStartCommand (intent, flags, startId);
    
    		}
    
    		#endregion
    
    	}
    
    	public class ServiceBinder : Binder
    	{
    		CalendarAlarmService service;
    
    		public ServiceBinder(CalendarAlarmService service)
    		{
    			this.service = service;
    		}
    
    		public CalendarAlarmService GetCalendarService()
    		{
    			return service;
    		}
    	}
    }
