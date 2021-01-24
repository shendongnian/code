    private bool on = true;
    private void button11_Click(object sender, EventArgs e)
    {
        if (on == true)
        {
            button11.Text = "Off";
            button11.BackColor = Color.LightGray;
            on = false;
        }
        else
        {
            button11.Text = "On";
            button11.BackColor = Color.DimGray;
            on = true;
        }
    }
