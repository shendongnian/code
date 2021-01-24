    if (InvokeRequired)
    {
    	UpdateUICallback d = new UpdateUICallback(UpdateUI);
    	this.Invoke(d);
    }
    else
    {
    	if (txt_ProgressDetails.Text.Length > 0)
                txt_ProgressDetails.AppendText(Environment.NewLine);
    	txt_ProgressDetails.AppendText(statusMessage);
    }
