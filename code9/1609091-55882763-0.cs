    this.RichTextBox.CommandBindings.Add(new CommandBinding(ApplicationCommands.Cut, this.RichTextBoxCutEvent));
    this.RichTextBox.CommandBindings.Add(new CommandBinding(ApplicationCommands.Cut, this.RichTextBoxCopyEvent));
    private void RichTextBoxCutEvent(object sender, ExecutedRoutedEventArgs e)
    {
        // The cut actions
    }
    private void RichTextBoxCopyEvent(object sender, ExecutedRoutedEventArgs e)
    {
        // The copy actions
    }
