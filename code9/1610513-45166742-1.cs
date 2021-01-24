    protected void btn1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt1.Text) && !string.IsNullOrEmpty(txt2.Text))
            {
    
                txt3.Text = (Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt2.Text)).ToString();
            }
        else {
            Response.Write("Please Enter Value");
        }
    }
