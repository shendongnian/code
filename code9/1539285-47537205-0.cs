    public void DragOver(IDropInfo dropInfo)
    {
        if(dropInfo.Data.GetType() == typeof(MyType))
        {
            dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            dropInfo.Effects = DragDropEffects.Copy;
        }
    }
