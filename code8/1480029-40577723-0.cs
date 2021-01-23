    private void checkBox1_Checked(object sender, EventArgs e)
    {
    var array = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5 };
    foreach(var checkbox in array)
    {
        if(checkbox != sender){
            checkbox.IsChecked = false
        }
    }
