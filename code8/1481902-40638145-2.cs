    int isvalid = 0;
    List<string> foods = new List<string> { "Cheese", "Vegetable", "Meat" };
    foreach(Control cb in this.Controls)
    {
        if(cb is ComboBox)
        {
            if(foods.Contains((ComboBox)cb.Text))
                isvalid++;
            else
                (ComboBox)cb.Text = "Wrong Input";
        }
    }
    if (isvalid == 3)
        return true;
    
    return false;
