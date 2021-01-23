    int isvalid = 0;
    List<string> foods = new List<string> { "Cheese", "Vegetable", "Meat" };
    foreach(ComboBox cb in ComboBoxes)
    {
        if(foods.Contains(cb.Text))
            isvalid++;
        else
            cb.Text = "Wrong Input";
    }
    if (isvalid == 3)
        return true;
    
    return false;
