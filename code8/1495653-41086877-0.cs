    private void button1_Click(object sender, EventArgs e)
    {
            if (textBox1.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Please fill out the boxes!");
                return;
            }
    
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
    
                message.From = new MailAddress("tamogatas.dolgozoadatbazis@gmail.com");
                message.To.Add(new MailAddress(Form1.cimzett)); <---- THIS LINE
                message.To.Add(new MailAddress("lalala@gmail.com"));
                message.To.Add(new MailAddress("lalala3@gmail.com"));
                message.To.Add(new MailAddress("lalala2@gmail.com"));
                message.Subject = textBox1.Text;
                message.Body = richTextBox1.Text + Environment.NewLine +  "This message was sent from " + (Login.loginnev);
    
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("USERNAME@gmail.com", "PASSWORD");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                MessageBox.Show("The mail was sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
    }
