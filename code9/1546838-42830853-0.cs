    protected void btnAddBarcode_Click(object sender, EventArgs e)
    {
        try
        {
    		Dictionary<int, string> Barcodes;
    		if (Session["Barcodes"] == null)
    		{
    			Barcodes = new Dictionary<int, string>();
    		}
    		else
    		{
    			Barcodes = (Dictionary<int, string>)Session["Barcodes"];
    		}
	    	int i = Convert.ToInt32(lblItemsScanned.Text);
            if (string.IsNullOrEmpty(txtBarcode.Text.Trim()))
            {
                ShowMessage("Please enter or scan barcode");
                return;
            }
            // Saving the Barcodes at first
            else if (i < Convert.ToInt32(hdnTotalItems.Value))
            {
                i++;
                if (i == 1)
                {
                    Barcodes.Add(i, txtBarcode.Text);
                    lblItemsScanned.Text = i.ToString();
                    Session["Barcodes"] = Barcodes;
    
                    txtBarcode.Text = string.Empty;
                    i++;
                }
            }
            else 
	    	{ 
    
            }
    
        }
	    catch(Exception) {}
    }
