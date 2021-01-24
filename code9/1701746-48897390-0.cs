    private void Form1_Load(object sender, EventArgs e)
    {
        using (var db = new mainEntities())
        {
            comboBox1.DataSource = db.Employers.ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Surname";
            comboBox1.SelectedIndex =0;
            //convert to long
            long id = Convert.ToInt64(comboBox1.SelectedValue);
            //get employer's ID
            var employer = (from s in db.Employers
                            where s.ID == id
                            select s).FirstOrDefault();
            //set 2 textboxes to Name and Surname values
            TextBox1.Text = employer.Name;
            TextBox2.Text = employer.Surname;
            //db.SaveChanges();
        }
    }
