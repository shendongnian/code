    private void TextBox_CharacterReceived(UIElement sender, CharacterReceivedRoutedEventArgs args)
            {
                TextBox TBx = (TextBox)sender;
    
                if (char.IsLower(args.Character))
                {
                    int Pos = TBx.SelectionStart;
                    TBx.Text = TBx.Text.ToUpper();
                    TBx.SelectionStart = Pos;
                    args.Handled = true;
                }
            }
