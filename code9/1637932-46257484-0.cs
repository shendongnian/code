    private int count;
    protected void btnCount_Click(object sender, EventArgs e)
     {
        count =   Int32.Parse(lblCount.Text);
        count++; 
        lblCount.Text = count.ToString();
     }
