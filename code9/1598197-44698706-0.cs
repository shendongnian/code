     protected void Button3_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                String body = @"Hi " + "<br/><br/>" +
                    "" + "Please note the current Flash Programming settings are incorrect. The Settings should be: " + "<br/>" +
                    "" + "Product : " + DropDownList1.Text + " Program Name : " + Label3.Text + " CRC : " + Label5.Text + " Daughter Card : " + Label7.Text + " Etching : " + Label9.Text + "<br/>" +
                    "" + "Currently the settings are :" + "<br/>" +
                    "" + "Product : " + DropDownList1.Text + " Program Name : ";
                if (Var1 == Label3.Text)
                {
                    body = body + Var1 + " CRC : ";
                }
                else 
                {
                    body += "<span style='color:red;'>" + Var1 + "</span>" + " CRC : ";
                }
                if (Var2 == Label5.Text)
                {
                    body = body + Var2 + " Daughter Card : ";
                }
                else
                {
                    body += "<span style='color:red;'>" + Var2 + "</span>" + " Daughter Card : ";
                }
                if (Var3 == Label7.Text)
                {
                    body = body + Var3 + " Etching : ";
                }
                else
                {
                    body += "<span style='color:red;'>" + Var3 + "</span>"  + " Etching : ";
                }
                if (Var4 == Label9.Text)
                {
                    body = body + Var4 + "<br/><br/>" + "" + "Regards" + "<br/>" + "" + "QC Team"; ;
                }
                else
                {
                    body += "<span style='color:red;'>" + Var4 + "</span>" + "<br/><br/>" + "" + "Regards" + "<br/>" + "" + "QC Team"; 
                }
                SmtpClient sptmClient = new SmtpClient("ra.uec.co.za");
                MailMessage m = new MailMessage();
                m.To.Add(new MailAddress("Rajiv.Sahadeo@uec.co.za"));
                m.From = new MailAddress("noreply@uec.co.za");
                m.Subject = "Incorrect Flash Programming Settings in Red";
                m.Body = body; 
                m.IsBodyHtml = true;
                sptmClient.Send(m);
                System.Windows.Forms.MessageBox.Show("NotificAation sent to Management");
                Response.Redirect(Request.Url.PathAndQuery,false);
            }
            else
            {
