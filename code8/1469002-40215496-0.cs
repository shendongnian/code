     protected void Button1_Click(object sender, EventArgs e)
        {
            tblContact tb = new tblContact();
            check += 1;
            if (check % 2 == 0)
            { 
               var student = (from c in db.tblContacts where c.name == lblName.Text select c).Single();
               student.Email = TextBox1.Text;
                TextBox1.Visible = false;
                Button1.Text = "edit";
                db.SubmitChanges();
            }
            else
            {
                TextBox1.Visible = true;
                Button1.Text = "Update";
            }
        }
