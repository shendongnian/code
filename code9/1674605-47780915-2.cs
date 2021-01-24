    if (InvokeRequired)
    {
    	UpdateUICallback d = new UpdateUICallback(AppendTextBoxLine);
    	this.Invoke(d, new object[] {statusMessage});
    }
    else
    {
    	if (txt_ProgressDetails.Text.Length > 0)
                txt_ProgressDetails.AppendText(Environment.NewLine);
    	txt_ProgressDetails.AppendText(statusMessage);
    }
