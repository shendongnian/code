    public static string ICSPath
    {
    	get
    	{
    		var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), StaticData.CalendarFolderName);
    		if (!Directory.Exists(path))
    			Directory.CreateDirectory(path);
    		return Path.Combine(path, StaticData.CalendarFileName);
    	}
    }
    
    
    public async Task<bool> ShareCalendarEvent(List<ISegment> segmentList)
    {
    	//Create the calendar file to attach to the email
    	var str = await GlobalMethods.CreateCalendarStringFile(segmentList);
    
    	if (File.Exists(ICSPath))
    	{
    		File.Delete(ICSPath);
    	}
    
    	File.WriteAllText(ICSPath, str);
    
    	MFMailComposeViewController mail;
    	if (MFMailComposeViewController.CanSendMail)
    	{
    		mail = new MFMailComposeViewController();
    		mail.SetSubject("Calendar Event");
    		//mail.SetMessageBody("this is a test", false);
    		NSData t_dat = NSData.FromFile(ICSPath);
    		string t_fname = Path.GetFileName(ICSPath);
    		mail.AddAttachmentData(t_dat, @"text/v-calendar", t_fname);
    
    		mail.Finished += (object s, MFComposeResultEventArgs args) =>
    		{
    			//Handle action once the email has been sent.
    			args.Controller.DismissViewController(true, null);
    		};
    
    		Device.BeginInvokeOnMainThread(() =>
    		{
    			UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(mail, true, null);
    		});
    
    	}
    	else
    	{
    		//Handle not being able to send email
    		await App.BasePageReference.DisplayAlert("Mail not supported", 
    		                                         StaticData.ServiceUnavailble, StaticData.OK);
    	}
    
    	return true;
    }
