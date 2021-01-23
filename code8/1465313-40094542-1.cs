    private void Lbl_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        var lbl = (Label)sender;
        Console.WriteLine("Label_OnMouseDown_BeforeDragging..." + DateTime.Now.Second);
        DragDrop.DoDragDrop(lbl, lbl.Content, DragDropEffects.Move);
        Console.WriteLine("Label_OnMouseDown_AfterDragging..." + DateTime.Now.Second);
    }
    private void UIElement_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        Console.WriteLine("Label_PreviewMouseDown..." + DateTime.Now.Second);
    }
