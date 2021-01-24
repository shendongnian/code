     public void methodStart(object sender, ElapsedEventArgs e)
                {
                    Ping p = new Ping();
                    PingReply r;
                    string s = "SYSTEM-IP-ADDRESS";
                    try
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            r = p.Send(s);
                            if (r.Status == IPStatus.Success)
                            {
                                 SuccessNoti();
    
                           }
                            else
                            {
        
                                UnsuccessfulNoti();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        UnsuccessfulNoti();
                    }
        
                    }
        
                } 
        		
        		 public void SuccessNoti()
                {
                    if ((string.Compare(status, "Down", false) == 0) && Successcount >= 7)
                    {
                        using (MailMessage mail = new MailMessage())
                        {
                            using (SmtpClient SmtpServer = new SmtpClient(smtp))
                            {
        					//  EMAIL NOTIFICATION
        
                                Successcount = 0;
                                status = null;
                            }
                        }
                    }
                    else
                    {
                        if (string.Compare(status, "Down", false) == 0)
                        {
                            Successcount = Successcount + 1;
                        }
                    }
                }
        		
        		 public void sendfailureNotofication()
                {
                    if (failureCount >= 7 && !(string.Compare(status, "Down", false) == 0))
                    {
        
                        status = "Down";
                        using (MailMessage mail = new MailMessage())
                        {
                            using (SmtpClient SmtpServer = new SmtpClient(smtp))
                            {
        					//  EMAIL NOTIFICATION
                               
                                failureCount = 0;
                                status = "Down";
                            }
                        }
                    }
                    else
                    {
                        if (!(string.Compare(status, "Down", false) == 0))
                        {
                            failureCount = failureCount + 1;
                        }
                    }
        
        
                }
