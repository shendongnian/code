     SqlConnection con = new SqlConnection("connection string");
            SqlCommand com = new SqlCommand("insert into BMS values(@value1)", con);
            com.Parameters.AddWithValue("@value1", p);
            try
            {
                com.Connection.Open();
                com.ExecuteNonQuery();
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("your email", "your display name");
                Msg.To.Add("to user name");
                string _fname = pictureBox1.ToString();
                Image image = pictureBox1.Image;
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                stream.Position = 0;
                Msg.Attachments.Add(new Attachment(stream, "Screenshot.jpg"));
                Msg.Subject = "user credential sent from bank ";
           
                Msg.Body = "content here ";
                Msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.cidcode.net";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("your email", "your password");
                smtp.Send(Msg);
                MessageBox.Show("Data inserted successfully and data's mailed ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test " + ex.Message);
                Console.WriteLine("{0} Exception caught.", ex);
            }
            finally
            {
                com.Connection.Close();
                com.Dispose();
            }
