    private void ButtonSubmit_Click(object sender, Eventargs e)
    {
        string a = TextBox_A.Text;
        int b = Convert.ToDouble(TextBox_B.Text);
        int c = Convert.ToDouble(TextBox_C.Text);
        int d = Convert.ToDouble(TextBox_D.Text);
        int e = Convert.ToDouble(TextBox_E.Text);
        YourTextBox.Text = func(a,b,c,d,e).ToString();
    }
