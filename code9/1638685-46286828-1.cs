    private void textBox1_Validated(object sender, EventArgs e)
    {
        TextBox t = (TextBox)sender;
        Common_Validated(t,e);
    }
    private void Common_Validated(TextBox txtName, EventArgs e)
    {
        DataTable dt = Person.DETECT_CHANGES(txtName.Text);
        foreach (DataRow row in dt.Rows)
        {
            if ((txtName.Text).Trim() != row["fullName"].ToString())
            {
                txtName.BackColor = Color.Yellow;
                break;
            }
            else
            {
                txtName.BackColor = Color.White;
            }
        }
    }
