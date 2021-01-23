    if (!IsPostBack)
    {
        string messageCode = Request.QueryString["MsgCode"];
        if (!string.IsNullOrEmpty(messageCode))
        {
            switch (messageCode)
            {
                case "1" :
                    lbleMailExist.Text = "eMail already in use, try Loging in";
                    break;
                case "2" :
                    lbleMailExist.Text = "Operation time-out, try Loging in";
                    break;
                    // populate conditions 
                default:
                    break;
            }
        }
    }
