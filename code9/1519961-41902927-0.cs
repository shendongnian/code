    public static string SendSms(string Message, string Phone, string BranchName)
    {
        try
        {
            var sms = new WebServiceSMS.SendMessageSoapClient();
            return sms.SendSms(WebConfigurationManager.AppSettings["UserName"], WebConfigurationManager.AppSettings["Pwd"], Message, Phone, BranchName, "0");
        }
        catch
        {
            return "Failed";
        }
    }
