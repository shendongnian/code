        try
        {
            IQueryable query = null;
            using (roosterAppEntities db = new roosterAppEntities())
            {
                query = from u in db.Users
                            where u.username == txtEmail.Text && u.password == txtPassword.Text
                            select u;                                         
            }
            if (query.SingleOrDefault() != null)
           {
                MessageBox.Show("Succesvol ingelogd! ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw;
        }
