    try
    {
                    var c = new Services.ServiceClient();
                
                    c.ClientCredentials.UserName.UserName = "test@tin.it";
                    c.ClientCredentials.UserName.Password= "pass";
     
                    Result ra = c.CheckCode("123");
     
                    if (ra.State == MessageStatusType.OK)
                    {
                        tbText.Text = "Connection ok: " + ra.TextState;
                    }
                    else
                    {
                        tbText.Text = "Connection ko: " + ra.TextState;
                    }
    }
    catch (Exception ex)
    {
        tbText.Text = ex.ToString();
    }
