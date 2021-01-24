     private void StackPanel_Drop(object sender, DragEventArgs e)
     {
        Rectangle newElement = new Rectangle();
        newElement.Width =  (dragItem as Rectangle).Width;
        newElement.Height = (dragItem as Rectangle).Height;
        newElement.Fill = (dragItem as Rectangle).Fill;
        StackPanelDropArea.Children.Add(newElement);
     }
