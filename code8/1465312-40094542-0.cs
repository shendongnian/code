    private void Lbl_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        var lbl = (Label)sender;
        DragDrop.DoDragDrop(lbl, lbl.Content, DragDropEffects.Move);
        Console.WriteLine("Drag...");
    }
    private void UIElement_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        Console.WriteLine("Label_PreviewMouseDown...");
    }
