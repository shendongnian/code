        try
            {
               foreach (GridViewRow item in GridView1.Rows)
               {
		         string Email_Address = item.Cells[1].Text.Trim();
                 MailMessage msg = new MailMessage();
		         msg.IsBodyHtml = true;
                 msg.From = new MailAddress("khawarsaleem90@gmail.com");
                 msg.To.Add(Email_Address);
                 msg.Subject = TextBox1.Text;
                 msg.Body = TextBox2.Text;
                 SmtpClient smt = new SmtpClient("smtp.gmail.com", 587);
                 smt.Credentials = new
                 System.Net.NetworkCredential("khawarsaleem90@gmail.com", "mypass");
                 smt.EnableSsl = true;
            try
                {
                 smt.Send(msg);
                 }
            
               catch (Exception ex)
                  {
                   throw new Exception(ex.Message.ToString());
                  }
               }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
