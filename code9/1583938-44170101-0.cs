    protected void Page_Load(object sender, EventArgs e)
    {
        string Themessage = @"<html>
                          <body>
                            <table width=""100%"">
                            <tr>
                                <td style=""font-style:arial; color:maroon; font-weight:bold"">
                               Hi! <br>
                                <img src=cid:myImageID>
                                </td>
                            </tr>
                            </table>
                            </body>
                            </html>";
        sendHtmlEmail("from@gmail.com", "tomailaccount", Themessage, "Scoutfoto", "Test HTML Email", "smtp.gmail.com", 25);
    }
    protected void sendHtmlEmail(string from_Email, string to_Email, string body, string           from_Name, string Subject, string SMTP_IP, Int32 SMTP_Server_Port)
    {
        //create an instance of new mail message
        MailMessage mail = new MailMessage();
        //set the HTML format to true
        mail.IsBodyHtml = true;
        //create Alrternative HTML view
        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
        //Add Image
        LinkedResource theEmailImage = new LinkedResource("E:\\IMG_3332.jpg");
        theEmailImage.ContentId = "myImageID";
        //Add the Image to the Alternate view
        htmlView.LinkedResources.Add(theEmailImage);
        //Add view to the Email Message
        mail.AlternateViews.Add(htmlView);
        //set the "from email" address and specify a friendly 'from' name
        mail.From = new MailAddress(from_Email, from_Name);
        //set the "to" email address
        mail.To.Add(to_Email);
        //set the Email subject
        mail.Subject = Subject;
        //set the SMTP info
        System.Net.NetworkCredential cred = new System.Net.NetworkCredential("fromEmail@gmail.com", "fromEmail password");
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.EnableSsl = true;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = cred;
        //send the email
        smtp.Send(mail);
    }
