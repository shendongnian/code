    
    protected void ButtonDelete_Click(object sender, EventArgs e)
    {
        int id;
        var button = (Button)sender;
        if(!int.TryParse(button.CommandArgument, out id))
        {
            // log.Write("possible sql injection");
            return;
        }
        //  do what you want
    }
