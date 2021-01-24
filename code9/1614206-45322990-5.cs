          private void EmailEmployeeDepartment(int DeptartmentId)
          {
            SmtpClient mailClient = new SmtpClient("HostName");
            MailMessage msgMail = new MailMessage(); 
    
            foreach (var temp in GetEmailPerDepartmentGroup(5))
            {
                msgMail.To.Add(temp);
            }
    
            msgMail.Subject = "Subject Text";
            msgMail.Body = "Email text";
          }     
     
