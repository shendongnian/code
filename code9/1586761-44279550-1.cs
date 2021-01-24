    private void buttonNew_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        Console.WriteLine(btn.Name + " says hiho");
        btn.Parent.Controls["panel41"].BackColor = Color.ForestGreen;
        ((RadioButton)btn.Parent.Controls["radioButton11"]).Checked = true;  
    }
