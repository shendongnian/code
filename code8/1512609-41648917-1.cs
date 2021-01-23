            using (DatabaseEntities dbc = new DatabaseEntities())
            {
                DbSet<user> dbs = dbc.users;
                IQueryable<user> q = from p in dbs
                where p.Booking.event_id == id
                select p;
                List<user> model = q.ToList<user>();
                ViewBag.ButtonText = "Send Reminder Email";
                return View("ViewDetails", model);
                
            }
            
        }
    [HttpPost]
        public ActionResult SendReminder(string[] userId)
        {            
            using (SmtpClient objSmtpClient = new SmtpClient())
            {
                for (int emailCount = 0; emailCount < userId.Length; emailCount++)
                {
                    if (!string.IsNullOrEmpty(userId[emailCount]))
                    {
                        using (MailMessage mail = new MailMessage("sender@gmail.com", userId[emailCount].Trim()))
                        {
                            mail.Subject = "Test Email";
                            mail.Body = "Test Body";
                            mail.IsBodyHtml = true;
                            using (SmtpClient smtp = new SmtpClient())
                            {
                                smtp.Host = "smtp.gmail.com";
                                smtp.Port = 587;
                                smtp.Credentials = new    System.Net.NetworkCredential("sender@gmail.com", "password");
                                smtp.EnableSsl = true;
                                mail.IsBodyHtml = true;
                                smtp.Send(mail);
                            }
                        }
                    }
                }
            }
            return View();
        }
