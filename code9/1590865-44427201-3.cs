    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        var modifierKeys = new[]
        {
            Key.LeftCtrl, Key.RightCtrl,
            Key.LeftAlt, Key.RightAlt,
            Key.LeftShift, Key.RightShift,
            Key.LWin, Key.RWin
        };
        var key = e.Key;
        if (key == Key.System)
            key = e.SystemKey;
        else if (key == Key.ImeProcessed)
            key = e.ImeProcessedKey;
        if (modifierKeys.Contains(key))
        {
            Label_Test.Content = string.Empty;
            return;
        }
        var modifiers = Keyboard.Modifiers;
        var modifiersPressed = Enum.GetValues(typeof(ModifierKeys))
                                   .OfType<ModifierKeys>()
                                   .Where(k => k != ModifierKeys.None && modifiers.HasFlag(k));
        Label_Test.Content = string.Join("+", modifiersPressed.OfType<object>()
                                                              .Concat(new object[] { key }));
    }
