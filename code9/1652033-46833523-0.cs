    using System;
    using XXX.Droid.LocalNotifications.Dependency;
    using XXX.LocalNotifications.Interfaces;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Android.Content;
    using Android.App;
    using Xamarin.Forms;
    using XXX.LocalNotifications;
    
    [assembly: Dependency (typeof (LocalNotificationManager_Android))]
    namespace XXX.Droid.LocalNotifications.Dependency
    {
    	public class LocalNotificationManager_Android: ILocalNotificationManager
    	{
    		#region ILocalNotificationManager implementation
    
    		public void RegisterLocalNotification (Notification notification)
    		{
    			RegisterNotification (notification);
    		}
    
    		public void RegisterLocalNotification (List<Notification> notifications)
    		{
    			foreach (var notification in notifications) {
    				RegisterNotification (notification);
    			}
    		}
    
    		public void UnRegisterLocalNotification (Notification notification)
    		{
    			var localNotification = File.ReadAllLines (LogFilePath).FirstOrDefault (noti => noti == notification.Guid);
    			if (!string.IsNullOrWhiteSpace (localNotification)) {
    				UnRegisterNotification (notification);
    			}
    		}
    
    		public void UnRegisterLocalNotification (List<Notification> notifications)
    		{
    			foreach (var notification in notifications) {
    				var localNotification = File.ReadAllLines (LogFilePath).FirstOrDefault (noti => noti == notification.Guid);
    				if (!string.IsNullOrWhiteSpace (localNotification)) {
    					UnRegisterNotification (notification);
    				}
    			}
    		}
    
    		public void UnRegisterAllNotifications ()
    		{
    			try{
    				var notificationInfo = File.ReadAllLines(LogFilePath);
    				foreach(var line in notificationInfo)
    				{
    					try{
    						var notification = new Notification(line);
    						UnRegisterNotification(notification);
    					}catch(Exception ex){
    						Console.WriteLine(ex.Message);
    					}
    				}
    				File.Delete(LogFilePath);
    			}catch(Exception ex){
    				Console.WriteLine(ex.Message);
    			}
    		}
    
    		public void RegisterService ()
    		{
    			if (!File.Exists (LogFilePath)) {
    				var file= File.Create (LogFilePath);
    				file.Close();
    
    			}
    		}
    
    		public bool IsServiceRegistered {
    			get {
    				return true;
    			}
    		}
    
    		#endregion
    
    		private string LogFilePath
    		{
    			get{
    				var documents = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
    				var logFile = Path.Combine (documents, "notificationsinfo.txt");
    				if (!File.Exists (logFile)) {
    					var file= File.Create (logFile);
    					file.Close();
    				}
    				return logFile;
    			}
    		}
    
    		private void UnRegisterNotification(Notification notification)
    		{
    			Intent intent1 = new Intent(Forms.Context, typeof(CalendarReceiver));
    			intent1.SetData (Android.Net.Uri.Parse ("custom://" + notification.Guid));
    			intent1.SetAction (notification.Guid);
    			intent1.PutExtra ("Title", notification.Title);
    			intent1.PutExtra ("Message", notification.Message);
    
    			PendingIntent pendingIntent = PendingIntent.GetBroadcast(
    				Forms.Context, 0, intent1,
    				PendingIntentFlags.UpdateCurrent);
    
    			try{
    				AndroidAlarmManager.Cancel (pendingIntent);
    				var notificationInfo = new List<string>(File.ReadAllLines(LogFilePath));
    				notificationInfo.Remove(notification.Guid);
    				File.WriteAllLines(LogFilePath, notificationInfo);
    			}catch(Exception ex) {
    				Console.WriteLine(ex.Message);
    			}
    
    		}
    
    		private void RegisterNotification(Notification notification)
    		{
    			if (string.IsNullOrWhiteSpace (notification.Title)) {
    				throw new NullReferenceException ("Title must be setted");
    			}
    
    			if (string.IsNullOrWhiteSpace(notification.Message)) {
    				throw new NullReferenceException ("Message must be setted");
    			}
    
    			if (!notification.Date.HasValue) {
    				throw new NullReferenceException ("DateTime must be setted");
    			}
    
    			if (notification.Date < DateTime.Now && notification.Interval == RepeatInterval.None) {
    				throw new ArgumentException ("DateTime must be greater than DateTime.Now");
    			}
    
    			Intent intent1 = new Intent(Forms.Context, typeof(CalendarReceiver));
    			intent1.SetData (Android.Net.Uri.Parse ("custom://" + notification.Guid));
    			intent1.SetAction (notification.Guid);
    			intent1.PutExtra ("Title", notification.Title);
    			intent1.PutExtra ("Message", notification.Message);
    			var daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
    
    			PendingIntent pendingIntent = PendingIntent.GetBroadcast(
    				Forms.Context, 0, intent1,
    				PendingIntentFlags.UpdateCurrent);
    
    			switch (notification.Interval)
    			{
    				case RepeatInterval.Daily:
    					AndroidAlarmManager.SetRepeating(AlarmType.RtcWakeup, GetMilisecondsUntilNextCheck(notification.Date.Value),
    					AlarmManager.IntervalDay, pendingIntent);
    					break;
    				case RepeatInterval.Weekly:
    					AndroidAlarmManager.SetRepeating(AlarmType.RtcWakeup, GetMilisecondsUntilNextCheck(notification.Date.Value),
    					AlarmManager.IntervalDay * 7, pendingIntent);
    					break;
    				case RepeatInterval.Monthly:
    					AndroidAlarmManager.SetRepeating(AlarmType.RtcWakeup, GetMilisecondsUntilNextCheck(notification.Date.Value),
    					AlarmManager.IntervalDay * daysInCurrentMonth, pendingIntent);
    					break;
    				case RepeatInterval.None:
    					AndroidAlarmManager.Set(AlarmType.RtcWakeup, GetMilisecondsUntilNextCheck(notification.Date.Value), pendingIntent);
    					break;
    			}
    
    			try{
    				var notificationInfo = new List<string>(File.ReadAllLines(LogFilePath));
    				notificationInfo.Add(notification.Guid);
    				File.WriteAllLines(LogFilePath, notificationInfo);
    			}catch(Exception ex){
    				Console.WriteLine(ex.Message);
    			}
    		}
    
    		public static long GetMilisecondsUntilNextCheck(DateTime next)
    		{
    			DateTime now = DateTime.Now;
    			DateTime todayAtTime = now.Date.AddHours(next.Hour).AddMinutes(next.Minute);
    			DateTime nextInstance = now <= todayAtTime ? todayAtTime : todayAtTime.AddDays(1);
    			TimeSpan span = nextInstance - now;
    			using (var cal = Java.Util.Calendar.GetInstance(Java.Util.TimeZone.Default))
    			{
    				cal.Set (Java.Util.CalendarField.Millisecond, 0);
    				cal.Add(Java.Util.CalendarField.Millisecond, (int)span.TotalMilliseconds);
    				return cal.TimeInMillis;
    			}
    		}
    
    		public void UnRegisterLocalNotification(string notificationGuid)
    		{
    			Intent intent1 = new Intent(Forms.Context, typeof(CalendarReceiver));
    			intent1.SetData(Android.Net.Uri.Parse("custom://" + notificationGuid));
    			intent1.SetAction(notificationGuid);
    
    			PendingIntent pendingIntent = PendingIntent.GetBroadcast(
    				Forms.Context, 0, intent1,
    				PendingIntentFlags.UpdateCurrent);
    
    			try
    			{
    				AndroidAlarmManager.Cancel(pendingIntent);
    				var notificationInfo = new List<string>(File.ReadAllLines(LogFilePath));
    				notificationInfo.Remove(notificationGuid);
    				File.WriteAllLines(LogFilePath, notificationInfo);
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine(ex.Message);
    			}
    		}
    
    		AlarmManager AndroidAlarmManager { get; set; }
    
    		public LocalNotificationManager_Android ()
    		{
    			AndroidAlarmManager = (AlarmManager) Forms.Context.GetSystemService(Context.AlarmService);
    		}
    	}
    }
