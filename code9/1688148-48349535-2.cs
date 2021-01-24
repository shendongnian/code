    private void StartDrag(MouseEventArgs e)
            {
                IsDragging = true;
    
                DataObject data = new DataObject(System.Windows.DataFormats.Text.ToString(), "abcd");
    
                DragDropEffects de = DragDrop.DoDragDrop(this.DragSource, data, DragDropEffects.Move);
    
                IsDragging = false;
            }
