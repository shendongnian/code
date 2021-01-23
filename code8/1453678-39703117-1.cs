    private void SetHotKey(object sender, KeyEventArgs e)
    {
        var nonShortcuttableKeys = new[] { Key.LeftAlt, Key.RightAlt, Key.LeftCtrl, Key.RightCtrl, Key.LeftShift, Key.RightShift };
        var actualKey = e.RealKey();
        if (e.IsDown && !nonShortcuttableKeys.Contains(actualKey))
        {
            var tb = sender as TextBox;
            var modifiers = new List<ModifierKeys>();
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            {
                modifiers.Add(ModifierKeys.Control);
            }
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Alt))
            {
                modifiers.Add(ModifierKeys.Alt);
            }
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
            {
                modifiers.Add(ModifierKeys.Shift);
            }
            tb.Text = modifiers.Count == 0
                ? string.Format("{0}", actualKey)
                : string.Format("{0} + {1}", string.Join(" + ", modifiers), actualKey);
            Hotkey = actualKey;
        }
        e.Handled = true;
    }
