    private void Form_Load(object sender, EventArgs e)
    {
        while(someLoop)
        {
            TextBox theTextBox = new TextBox();
            theTextBox.Name = "SomeUniqeName";//Maybe team name?
            theTextBox.KeyUp += TheTextBox_KeyUp;
        }
    }
    private void TheTextBox_KeyUp(object sender, KeyEventArgs e)
    {
        if ( e.KeyCode == Keys.Enter )
        {
            TextBox textbox = (TextBox) sender;//Get the textbox
            //Just an example
            listOfTeams.First( r => r.TeamName == textbox.Name )
                       .SomeOtherProperty = textbox.Text;
        }
    }
