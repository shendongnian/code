    <Checkbox Name="myCheckBox" />
    private void myCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (myCheckBox.Checked)
        {
            Console.WriteLine("my checkbox is checked.");
        }
        else if (!myCheckBox.Checked)
        {
            Console.WriteLine("my checkbox is not checked."); 
        }
    }
