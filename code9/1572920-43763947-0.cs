    public MyPage()
    {
        my_switch.IsToggled = Done;
    }
    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        Done = my_switch.IsToggled;
    }
