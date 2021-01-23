    protected void ButtonInChild_Click(object sender, EventArgs e)
    {
        Button button = this.Master.FindControl("Button1") as Button;
        button.Visible = false;
    }
