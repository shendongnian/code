    private void ComboBox1_SelectedIndexChanged(object sender,System.EventArgs e)
      {
        long id = Convert.ToInt64(comboBox1.SelectedValue);
            using (var db = new mainEntities())
        {
            var employer = (from s in db.Employers
                            where s.ID == id
                            select s).FirstOrDefault();
            //set 2 textboxes to Name and Surname values
            TextBox1.Text = employer.Name;
            TextBox2.Text = employer.Surname;       
        }
      }
