    public static string ICSPath
    {
    	get
    	{
    		var path = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, StaticData.CalendarFolderName);
    		if (!Directory.Exists(path))
    			Directory.CreateDirectory(path);
    		return Path.Combine(path, StaticData.CalendarFileName);
    	}
    }
    
    public async Task<bool> ShareCalendarEvent(List<ISegment> segmentList)
    {
    	Intent choserIntent = new Intent(Intent.ActionSend);
    
    	//Create the calendar file to attach to the email
    	var str = await GlobalMethods.CreateCalendarStringFile(segmentList);
    
    	if (File.Exists(ICSPath))
    	{
    		File.Delete(ICSPath);
    	}
    
    	File.WriteAllText(ICSPath, str);
    
    	Java.IO.File filelocation = new Java.IO.File(ICSPath);
    	var path = Android.Net.Uri.FromFile(filelocation);
    
    	// set the type to 'email'
    	choserIntent.SetType("vnd.android.cursor.dir/email");
    	//String to[] = { "asd@gmail.com" };
    	//emailIntent.putExtra(Intent.EXTRA_EMAIL, to);
    	// the attachment
    	choserIntent.PutExtra(Intent.ExtraStream, path);
    	// the mail subject
    	choserIntent.PutExtra(Intent.ExtraSubject, "Calendar event");
    	Forms.Context.StartActivity(Intent.CreateChooser(choserIntent, "Send Email"));
    
    	return true;
    
    }
