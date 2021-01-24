	var note = new NSUserNotification
	{
		Title = "StackOverflow",
		DeliveryDate = NSDate.FromTimeIntervalSinceNow(30)
			
	};
	NSUserNotificationCenter.DefaultUserNotificationCenter.ScheduleNotification(note);
	NSApplication.SharedApplication.Terminate(new NSObject());
