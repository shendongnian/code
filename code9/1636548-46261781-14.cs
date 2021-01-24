    protected void Button1_Click(object sender, EventArgs e)
    {
        // Introducing delay for demonstration.
        System.Threading.Thread.Sleep(3000);
        Label1.Text = "Page refreshed at " +
            DateTime.Now.ToString();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Introducing delay for demonstration.
        System.Threading.Thread.Sleep(3000);
        Label1.Text = "Page refreshed with DDL at " +
            DateTime.Now.ToString();
    }
