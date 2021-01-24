    for (int j = 0; j < DatMsg.Tables[0].Rows.Count; j++)
    {
    	ToEmail = DatMsg.Tables[0].Rows[j].ItemArray.GetValue(1).ToString();
    	ToName = DatMsg.Tables[0].Rows[j].ItemArray.GetValue(0).ToString();
    	AlertList.Add(DatMsg.Tables[0].Rows[j].ItemArray.GetValue(4).ToString() + "<br/>");
    	TotMsg = (j + 1).ToString();
    	
    	string to = ToEmail;
    	string from = "helpdesk@mydomain.com";
    	string subject = "Alert In Time : You Have "+TotMsg+ " Alerts";
    	string msgBody = "Dear " + ToName + ",<br/><br/>";
    	msgBody += "<b>You Have " + TotMsg + " Alerts</b><br/><br/>";
    	msgBody += string.Join("<br/>", AlertList);
    	msgBody += "<br/><br/>Regards<br/>Sent by Alert Service<br/>(Please do not reply to this email.)";
    	MailMessage msg = new MailMessage(from, to, subject, msgBody);
    	msg.IsBodyHtml = true;
    	SmtpClient clnt = new SmtpClient("outlook.mydomain.local", 25);
    	clnt.EnableSsl = false;
    	clnt.Credentials = new System.Net.NetworkCredential("helpdesk@mydomain.com", "password");
    	clnt.Send(msg);
    }
                    
