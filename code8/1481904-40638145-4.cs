    int isvalid = 0;
    List<string> foods = new List<string> { "Cheese", "Vegetable", "Meat" };
    List<string> cbNames = new List<string> { "comboBox1", "comboBox2", "comboBox3" }; //If you have more than the three comboBoxes
    foreach(Control cb in this.Controls)
    {
        if(cb is ComboBox)
        {
            if(foods.Contains((ComboBox)cb.Text) &&  cbNames.Contains((ComboBox)cb.Name))
            //Only use the second condition if you have more than the three comboBoxes
                isvalid++;
            else
                (ComboBox)cb.Text = "Wrong Input";
        }
    }
    if (isvalid == 3)
        return true;
    
    return false;
