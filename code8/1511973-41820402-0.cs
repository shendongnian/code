        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                billprint.ExportToDisk(ExportFormatType.PortableDocFormat, "E:\\" + filename);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                MailMessage mm = new MailMessage();
                string toemail = BLDashboard.email;
                string custnm = BLDashboard.custname;
                mm.From = new MailAddress("operations@kaem.in", "Kashif Ahhmed");
                mm.To.Add(new MailAddress(toemail, custnm));
                mm.IsBodyHtml = true;
                string name = BLDashboard.custname;
                mm.Subject = "Bill from Indian Restaurant";
                //mm.Body = "Testing Crsytel Report Attachment send via Email";
               
                String Body = "<div>Hello " + name + ",<br> Thank you for considersing us for your next Party/Event, here is the Bill for the Party/Event.<br> If any queries you can reach us at 6096464445. <br> Thank You</div>";
                mm.Body = Body;
                //mm.Attachments.Add(new Attachment(rpt.ExportToStream(ExportFormatType.PortableDocFormat), fileName));  
                mm.Attachments.Add(new Attachment("E:\\" + filename));
                SmtpClient sc = new SmtpClient("smtp.kaem.in");
                sc.Credentials = new NetworkCredential("emailadd", "*********");
                sc.Send(mm);
                // MailMessage msg = mm.CreateMailMessage("mr.markwhite1@gmail.com", replacements, Body, new System.Web.UI.Control());  
                MessageBox.Show("Email successfully sent to " + toemail);
            }
            catch (Exception e1)
            {
                MessageBox.Show("Unable to send email to mr.markwhite1@gmail.com due to following error:\n\n" + e1.Message, "Email send error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //{
                //    this.SendEmail(emailId, subject, body, rpt, fileName);
                //}
            }
        }
