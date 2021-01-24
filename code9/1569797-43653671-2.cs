    private void ClickMebutton_Click(object sender, EventArgs e)
    {
        int i = Int32.Parse(label1.Text);
        i++;
        label1.Text = i.ToString();
    }
