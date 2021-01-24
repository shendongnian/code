    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.Source is CustomTextBox sourceTextBox && sourceTextBox.Name.Equals("textSource"))
        {
            return;
        }
    
        base.OnKeyDown(e);
    
        if (e.Key == Key.Enter && EnterKeyCommand != null)
        {
            if (EnterKeyCommand.CanExecute(null))
            {
                EnterKeyCommand.Execute(null);
            }
        }
    }
