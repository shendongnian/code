    [System.Web.Services.WebMethod()]
    public static void RunOnClose()
            {
                PageInformation InfoView = new PageInformation ();
    
            InfoView = (PageInformation )ViewState["PBLSave"];
    
            if (txtValidFPGTE18MQ1.Text != InfoView.FPGTE18.Q1.ToString() || txtValidFPGTE18MQ2.Text != InfoView.FPGTE18.Q2.ToString()
                || txtValidFPGTE18MQ3.Text != InfoView.FPGTE18.Q3.ToString() || txtValidFPGTE18MQ4.Text != InfoView.FPGTE18.Q4.ToString()
                || txtValidFPGTE18MQ5.Text != InfoView.FPGTE18.Q5.ToString() || txtValidFPGTE18MQ6.Text != InfoView.FPGTE18.Q6.ToString())
            {
                mdlPopupExtender.Show();
            }
            else
            {
                redirectUrl = "../UI/Summary_Page.aspx";
                Response.Redirect(redirectUrl);
            }
            }
