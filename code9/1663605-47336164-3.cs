    private void create_projectname_button1_Click(object sender, EventArgs e)
    {
        if (lbGetFirstName.SelectedItems.Count==0)
        {
            label1.Text = "YYY-PKT-100";
        }
        if (lbGetlastName.SelectedItems.Count==0)
        {
            label1.Text = "XXX-PKT-100";
        }
        if (string.IsNullOrWhiteSpace(textBox1.Text))
        {
            label1.Text = "XXX-YYY";
        }
        else
        {
            label1.Text = lbGetFirstName.SelectedItem + "-" + listBox2.SelectedItem + "-" + lbGetlastName.Text;
        }
    }
