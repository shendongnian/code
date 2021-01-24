    private IDropTargetHelper ddHelper = (IDropTargetHelper)new DragDropHelper();
    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Copy;
        Point p = Cursor.Position;
        Win32Point wp;
        wp.x = p.X;
        wp.y = p.Y;
        ddHelper.Drop(e.Data as IDataObject_Com, ref wp, (int)e.Effect);
    }
    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Copy;
        Point p = Cursor.Position;
        Win32Point wp;
        wp.x = p.X;
        wp.y = p.Y;
        ddHelper.DragEnter(this.Handle, e.Data as IDataObject_Com, ref wp, (int)e.Effect);
    }
    private void Form1_DragLeave(object sender, EventArgs e)
    {
        ddHelper.DragLeave();
    }
    private void Form1_DragOver(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Copy;
        Point p = Cursor.Position;
        Win32Point wp;
        wp.x = p.X;
        wp.y = p.Y;
        ddHelper.DragOver(ref wp, (int)e.Effect);
    }
