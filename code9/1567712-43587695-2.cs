    string[] Teams = { "teamA", "teamB", "teamC" };
    private void Form1_Load(object sender, EventArgs e)
    {
        for ( int i = 0; i < Teams.Length; i++ )
        {
            TextBox theTextBox = new TextBox();
            //Prefix the name so we know this is a betting textbox
            //Add the 'name' (teams[i] in this case) to find it
            theTextBox.Name = "ThePrefix" + Teams[i];
        }
            
    }
    private void someButton_Click(object sender, EventArgs e)
    {
        //We want all betting textbox's here but also by team name
        for ( int i = 0; i < Teams.Length; i++ )
        {
            //Because we set the name, we can now find it with linq
            TextBox textBox = (TextBox) this.Controls.Cast<Control>()
                .FirstOrDefault( row => row.Name == "ThePrefix" + Teams[i] );
        }
    }
