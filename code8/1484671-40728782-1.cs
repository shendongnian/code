	MyBackGroundWorkerObject myBackGroundWorker1 = new MyBackGroundWorkerObject();
	MyBackGroundWorkerObject.AccountName acct = new MyBackGroundWorkerObject.AccountName();
        //AccountName acct = new AccountName();
        acct.AccountSid = "abcd";
        acct.AuthToken = "xyz";
        acct.Name = "Potato";
        ddlAccounts.Items.Add(acct);
	MyBackGroundWorkerObject.TimeZone region = new MyBackGroundWorkerObject.TimeZone();
        //TimeZone region = new TimeZone();
        region.Zone = "UTC";
        region.difference = 0;
        comboBox1.Items.Add(region);
		
	myBackGroundWorker1.TheTimeZone = region;
	myBackGroundWorker1.TheAccountName = acct;
	
	backgroundWorker1.RunWorkerAsync(myBackGroundWorker1);
	
