    private void subtractBtn_Click(object sender, EventArgs e)
    {
        int Subtract = Convert.ToInt32(textBox_Subtract.Text);
        remaining = needed - Subtract;
        needed = remaining;
        textBox_Remaining.Text = remaining.ToString();
        if (remaining <=0)
        {
            MessageBox.Show("Hey it's done");
        }
    }
