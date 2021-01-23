csharp
class NoShortcutTextBox : TextBox
{
    /// <summary>
    /// Occurs when a key is pressed while focus is on this element. Apply to all shortcuts like
    /// Ctrl-C or Ctrl-V
    /// </summary>
    public new event KeyEventHandler KeyDown;
    public NoShortcutTextBox()
    {
        CommandManager.AddPreviewCanExecuteHandler(this, CanExecute);
        // Workaround as we cannot raise event in base class, so we hide it and use
        // our version of KeyDown instead
        base.KeyDown += (sender, e) => KeyDown(sender, e);
        // --Demo--
        KeyDown += (sender, e) =>
        {
            // Fetch the actual shortcut key
            var key = (e.Key == Key.System ? e.SystemKey : e.Key);
            if (key == Key.LeftShift || key == Key.RightShift
            || key == Key.LeftCtrl || key == Key.RightCtrl
            || key == Key.LeftAlt || key == Key.RightAlt
            || key == Key.LWin || key == Key.RWin) return;
            var sb = new StringBuilder();
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            {
                sb.Append("Ctrl+");
            }
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
            {
                sb.Append("Shift+");
            }
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Alt))
            {
                sb.Append("Alt+");
            }
            Console.WriteLine(sb.Append(key.ToString()).ToString());
        };
    }
    private void CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.Handled = true;
        if (!(e.Command is RoutedUICommand command)) return;
        switch (command.Text)
        {
            case "Copy":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.C));
                break;
            case "Cut":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.X));
                break;
            case "Paste":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.V));
                break;
            case "Select All":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.A));
                break;
            case "Undo":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.Z));
                break;
            case "Redo":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.Y));
                break;
            case "Backspace":
            case "DeletePreviousWord":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.Back));
                break;
            case "Delete":
            case "DeleteNextWord":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.Delete));
                break;
            case "MoveToLineStart":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.Home));
                break;
            case "MoveToLineEnd":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.End));
                break;
            case "ToggleInsert":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.Insert));
                break;
            case "MoveUpByPage":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.PageUp));
                break;
            case "MoveDownByPage":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.PageDown));
                break;
            case "MoveLeftByCharacter":
            case "MoveLeftByWord":
            case "SelectLeftByWord":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.Left));
                break;
            case "MoveRightByCharacter":
            case "MoveRightByWord":
            case "SelectRightByWord":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.Right));
                break;
            case "MoveDownByLine":
            case "MoveDownByParagraph":
            case "SelectDownByParagraph":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.Down));
                break;
            case "MoveUpByLine":
            case "MoveUpByParagraph":
            case "SelectUpByParagraph":
                KeyDown?.Invoke(this, GetKeyEventArgs(Key.Up));
                break;
        }
    }
    private KeyEventArgs GetKeyEventArgs(Key key)
    {
        return new KeyEventArgs(
            Keyboard.PrimaryDevice,
            new HwndSource(0, 0, 0, 0, 0, "", IntPtr.Zero), // dummy source
            0,
            key)
        {
            RoutedEvent = TextBox.KeyDownEvent,
        };
    }
}
