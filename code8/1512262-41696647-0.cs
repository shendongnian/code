    public string GetCertificateBase64(string certificateSerialNumber)
    {
    	string certificateBase64 = string.Empty;
    
    	try
    	{
    		// Variables
    		CERTADMINLib.CCertView certView = null;
    		CERTADMINLib.IEnumCERTVIEWROW certViewRow = null;
    		CERTADMINLib.IEnumCERTVIEWCOLUMN certViewColumn = null;
    		int iColumnCount = 0;
    		object objValue = null;
    
    		// Connecting to the Certificate Authority
    		certView = new CERTADMINLib.CCertView();
    		certView.OpenConnection(this.nameCA);
    
    		// Get a column count and place columns into the view
    		iColumnCount = certView.GetColumnCount(0);
    		certView.SetResultColumnCount(iColumnCount);
    
    		// Place each column in the view.
    		for (int x = 0; x < iColumnCount; x++)
    		{
    			certView.SetResultColumn(x);
    		}
    
    		int certificateSerialNumberColumnIndex = certView.GetColumnIndex(0, "SerialNumber");
    		object objSerialNumber = certificateSerialNumber;
    		certView.SetRestriction(certificateSerialNumberColumnIndex, CVR_SEEK_EQ, CVR_SORT_NONE, ref objSerialNumber);
    
    		// Open the View and reset the row position
    		certViewRow = certView.OpenView();
    		certViewRow.Reset();
    
    		// Enumerate Row and Column Information
    
    		// Rows (one per cert) 
    		for (int x = 0; certViewRow.Next() != -1; x++)
    		{
    			// Columns with the info we need
    			certViewColumn = certViewRow.EnumCertViewColumn();
    			while (certViewColumn.Next() != -1)
    			{
    				switch (certViewColumn.GetDisplayName())
    				{
    					// Binary Certificate
    					case "Binary Certificate":
    						objValue = certViewColumn.GetValue(CV_OUT_BASE64);
    						if (objValue != null)
    						{
    							certificateBase64 = objValue.ToString();
    						}
    						break;
    
    					default:
    						break;
    				}
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		certificateBase64 += Environment.NewLine + "ex: " + ex.Message;
    	}
    
    	return certificateBase64;
    }
