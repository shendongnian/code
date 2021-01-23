    private async Task Perform()
    {
        lbl1.BackColor = Color.Red;    
        lbl2.BackColor = Color.Red;
        await Task.Delay(2000);
        lbl1.Text = val1.ToString();  
        lbl2.Text = val2.ToString();
        await Task.Delay(2000);
        lbl1.BackColor = Color.LightSeaGreen;  //changed to lightseagreen as the green you used
        lbl2.BackColor = Color.LightSeaGreen;  //was hurting my eyes :P
    }
