    var buttonDictionary = new Dictionary<string, Button>();
    buttonDictionary["J"] = btn1;
    buttonDictionary["M"] = btn2;
    //etc...
    if (buttonDictionary.Keys.Contains(txt1.Text))
    {
        txt1.Text = "";
        buttonDictionary[txt1.Text].Visible = false;
    }
