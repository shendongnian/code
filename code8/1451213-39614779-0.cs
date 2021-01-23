    public sealed class GenerateInvoice :
    {
    	protected const int timerInterval = 1000; // define here interval between ticks
    	
    	protected Timer timer = new Timer(timerInterval); // creating timer
    	
    	public GenerateInvoice()
    	{
    		timer.Elapsed += Timer_Elapsed;		
    	}
    	
    	public void Start()
    	{
    		timer.Start();
    	}
    	
    	public void Stop()
    	{
    		timer.Stop();
    	}
    	
        public void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {       
    		try
    		{
    			DBBilling obj = new DBBilling();
    			DataTable dtInvoiceID = obj.readData(@"SELECT * FROM (SELECT ird.BillByType, ird.InvoiceID, ir.BeginDate, ir.EndDate, ir.SendToQB, ir.SendEmail, 
    				i.ARAccountID, i.ARAccountHotelID, i.invoiceNumber,i.[STATUS],UPDATETIME,row_number() over (PARTITION BY ird.INVOICEID ORDER BY UPDATETIME DESC) AS row_number
    				FROM Invoices i JOIN  InvoicesRunRequestDetails ird ON ird.InvoiceID=i.InvoiceID 
    				JOIN InvoicesRunRequest ir ON ird.RequestID = ir.RequestID
    				Where i.[STATUS] = 'PENDING') AS rows
    				WHERE ROW_NUMBER=1 ORDER BY UPDATETIME");
    
    			processCounter = 0;
    
    			#region process
    			if (dtInvoiceID != null && dtInvoiceID.Rows.Count > 0)
    			{
    			  //some code here..
    			}
    			#endregion
    		}
    		catch (Exception ex)        //Mantis 1486 : WEBPMS1 Disk Space : 10 Aug 2016
    		{
    			log.ErrorFormat("Generate Invoice -> Process -> InnLink Billing Execute Query Exception. Error={0}", ex);
    			if(DBBilling.dbConnTimeoutErrorMessage.Any(ex.Message.Contains))
    			{
    				processCounter++;
    				if (processCounter >= 1) //Need to change to 25 after Problem Solve
    				{
    					isProcessActive = false;
    					// supposing that log is a reference type and one of the solutions can be using lock
    					// in that case only one thread at the moment will call log.ErrorFormat
                        // but better to make synchronization stuff unside logger
    					lock (log)
    						log.ErrorFormat("Generate Invoice -> Process -> RunInvoice Service exiting loop"); //From here control is not going back                
    				}
    				else 
    					// if you need here some kind of execution sleep 
    					// here you can stop timer, change it interval and run again
    				    // it's better than use Thread.Sleep
    				
    					// System.Threading.Thread.Sleep(5000);    //Sleep for 5 Sec
    			}
    		}                     
    	}
    }
