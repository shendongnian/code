    private void can_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }
        private void can_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                can.Children.Add(dragItem);
                dragItem.Visibility = Visibility.Visible;
                Canvas.SetTop(dragItem, dragItem.getPosition().Y);
                Canvas.SetLeft(dragItem, dragItem.getPosition().X);
                isDragging = false;
                resOnCanvas.Add(dragItem);
            }
        }
        private void can_DragOver(object sender, DragEventArgs e)
        {
            if (dragItem != null)
            {
                if (!dragItem.IsVisible)
                {
                    dragItem.Visibility = Visibility.Visible;
                }
                dragItem.setPosition(e.GetPosition(can));
                Console.WriteLine(dragItem.getPosition().X + " " + dragItem.getPosition().Y);
            }
        }
