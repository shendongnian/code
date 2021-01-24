    //Inside DraggableView.cs
    public void DragEnded()
    {
        IsDragging = false;
        //add this line and your command will be triggered
        this.RestorePositionCommand.Execute(null);
        DragEnd(this, default(EventArgs));
    }
