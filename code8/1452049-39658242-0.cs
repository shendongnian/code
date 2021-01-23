    string name = null;
    if( radiobutton1.Checked )
        name = radiobutton1.Text;
    else if( radiobutton2.Checked )
        name = radiobutton2.Text;
    else if( radiobutton3.Checked )
        name = radiobutton3.Text;
    if( name != null )
        MessageBox.Show( "Welcome " + name + ". How are you?" );
    else
        MessageBox.Show( "Please select a name!" );
