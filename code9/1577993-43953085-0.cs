    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _PART_SearchTextBox = (TextBox)GetTemplateChild("PART_SearchTextBox");
    }
    public void ClearSearchText()
    {
        SearchText = "";
        _PART_SearchTextBox.Focus();
    }
    private TextBox _PART_SearchTextBox;
    static void C_DeleteCommand(object sender, ExecutedRoutedEventArgs e)
    {
        CustomSearchControl mycontrol = sender as CustomSearchControl;
        mycontrol.ClearSearchText();
    }
