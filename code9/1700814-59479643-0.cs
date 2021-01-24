    static Keys ToWinFormsKeys(Key key, ModifierKeys modifiers)
    {
        Keys keys = (Keys)KeyInterop.VirtualKeyFromKey(key);
        if ((modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)
            keys |= Keys.Alt;
        if ((modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            keys |= Keys.Control;
        if ((modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            keys |= Keys.Shift;
        return keys;
    }
    static KeyGesture CreateGesture(Key key, ModifierKeys modifiers)
    {
        Keys formsKeys = ToWinFormsKeys(key, modifiers);
        string display = wFormsKeyConv.ConvertToString(formsKeys);
        return new KeyGesture(key, modifiers, display);
    }
