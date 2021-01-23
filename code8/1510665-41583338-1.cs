    public void LoadCal(System.DateTime ldate, int Selected)
    {
    
    	M = ldate.Month;
    	Y = ldate.Year;
    	D = ldate.Day;
    
    	clearall();
    	MonthName.Text = monthstr(ldate.Month) + " " + ldate.Year;
    	DayOfWeek fdate = GetFirstOfMonthDay(ldate);
    	int idate = 1;
    	int row = 1;
    
    	do {
    		getlabel(fdate, row).Text = idate;
    		getlabel(fdate, row).ForeColor = Label18.ForeColor;
    
    		//Current Date
    		if (idate == Selected & idate == System.DateTime.Now.Day & ldate.Month == System.DateTime.Now.Month) {
    			getlabel(fdate, row).ForeColor = Color.Red;
    		}
    
    		if (fdate == DayOfWeek.Saturday) {
    			row += 1;
    		}
    
    		fdate = tdate(fdate);
    		idate += 1;
    
    		if (su1.Text.Length == 0) {
    			psu1.BorderStyle = BorderStyle.None;
    			psu1.Enabled = false;
    		} else {
    			psu1.BorderStyle = BorderStyle.FixedSingle;
    			psu1.Enabled = true;
    		}
    
    		if (idate == System.DateTime.DaysInMonth(ldate.Year, ldate.Month) + 1) {
    			break; // TODO: might not be correct. Was : Exit Do
    		}
    	} while (true);
    }
    
    //=======================================================
    //Service provided by Telerik (www.telerik.com)
    //Conversion powered by NRefactory.
    //Twitter: @telerik
    //Facebook: facebook.com/telerik
    //=======================================================
