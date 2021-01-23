    //Set properties. Make the textBox looks like label
    yourTextBox.BackColor = SystemColors.Control;
    yourTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
    
    //Allow user to change text by double clicking it
    yourTextBox.DoubleClick += new EventHandler(this.doubleClick);
    
    //Do stuff when user double click it. Double click again to end editing.
    public void doubleClick(object sender, EventArgs e)
    {
        TextBox temp = (TextBox)sender;
        temp.ReadOnly = !temp.ReadOnly;            
        temp.DeselectAll();
        if (temp.ReadOnly)
        {
            //Make the textbox lose focus
            this.ActiveControl = null;
        }
    }
