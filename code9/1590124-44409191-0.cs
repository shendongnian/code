    public ButtonListViewModel(ViewRoleMapClass viewRoleButton)
    {
        //If IsEnabled for row in ConfigRole is FALSE
        if (viewRoleButton.IsEnabled == false)
        {
            ObservableCollection<ButtonRoleMapClass> butsList = new ObservableCollection<ButtonRoleMapClass>();
            if (_buttonList != null)
            {
                foreach (ButtonRoleMapClass button in _buttonList)
                {
                    button.IsEnabled = false;
                    butsList.Add(button);
                }
            }
            ButtonList = butsList;
        }
    }
