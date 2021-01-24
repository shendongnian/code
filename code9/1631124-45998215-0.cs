    <GridViewColumn Header="{x:Static GuiText.LoginView.HeaderValueText}" DisplayMemberBinding="{Binding Path=TranslatedValue}" />
----------
    public string TranslatedValue
    {
        get
        {
            return Resource1.String1;
        }
    }
