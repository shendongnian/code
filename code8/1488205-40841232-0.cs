        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
          TextBox1.Text = DropDownList1.SelectedValue.ToString();
          TextBox2.Text = DropDownList1.Items[2].ToString(); // 2 is your index
        }
