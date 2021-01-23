    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
          TextBox1.Text = DropDownList1.SelectedValue.ToString();
          TextBox2.Text = DropdownList1.SelectedItem.Tag.ToString();
    }
