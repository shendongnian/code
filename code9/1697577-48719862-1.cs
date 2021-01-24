    protected void Button1_Click(object sender, EventArgs e)
    {
        Questions.Add("Answer 1");
        Label1.Text = "There are " + Questions.Count() + " answers";
    }
