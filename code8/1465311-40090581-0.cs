    // Event fired immediately before DragDrop
    public DragEventHandler DragBegin { get; set; }
    private void Label_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        var lbl = (Label)sender;
        // Create args object and fire event if not null
        var args = new DragEventArgs(new DataObject(lbl.Content), DragDropKeyStates.None, DragDropEffects.None, lbl, e.GetPoint(lbl));
        DragBegin?.Invoke(sender, args);
        DragDrop.DoDragDrop(lbl, lbl.Content, DragDropEffects.Move);
        Console.WriteLine("Drag...");
    }
