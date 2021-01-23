    int isvalid = 0;
    List<string> foods = new List<string> { "Cheese", "Vegetable", "Meat" };
    foreach(Control cb in this.Controls)
    {
        if(cb is ComboBox)
        {
            if(foods.Contains(cb.Text))
                isvalid++;
        }
    }
    if (isvalid == 3)
        return true;
    
    return false;
