    private void TextBox_CharacterReceived(UIElement sender, CharacterReceivedRoutedEventArgs args)
            {
                TextBox TBx = (TextBox)sender;
    
                if (char.IsLower(args.Character))
                {
                    int Pos = TBx.SelectionStart;
                    char kc = char.ToUpper(args.Character);
                    TBx.Text = TBx.Text.Replace(args.Character, kc);
                    TBx.SelectionStart = Pos;
                    args.Handled = true;
                }
            }
