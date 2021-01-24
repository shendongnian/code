    public async Task<int> CarryOutPreRegisterDevice(string emailAddress)
    {
        ProgressDialog progressDialog;
        progressDialog = ProgressDialog.Show(AppGlobals.CurrentActivity, "", "Sending....", true);
        progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
        
        var intRet = await PreRegisterDevice(emailAddress);
        progressDialog.Dismiss();
        return intRet;
    }
