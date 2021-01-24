    public string SelectedValue
    {
        get { return selectedValue; }
        set 
        { 
            if (SetProperty(ref selectedValue, value)
            {
                //If property value changes, update the name property as well
                GetSelectedName();
            }
        }
    }
