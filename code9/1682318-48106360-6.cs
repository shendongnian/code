    private async void StackPanel_Drop(object sender, DragEventArgs e)
    {
        DataPackageView dataPackageView = Clipboard.GetContent();
        if (dataPackageView.Contains(StandardDataFormats.Text))
        {
            draggedObject = await dataPackageView.GetTextAsync();
        }
    
        // Dragged objects come from another one of our Parent's Children
        DependencyObject parent = VisualTreeHelper.GetParent(StackPanelDropArea);
        int count = VisualTreeHelper.GetChildrenCount(parent);
    
        for(int i=0; i< count; i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, i);
            if(child.GetType().Equals(typeof(StackPanel)))
            {
                StackPanel currentStackPanel = child as StackPanel;
                if(currentStackPanel.Name == "StackPanelRectangles")
                {
                    int numberOfRectangles = VisualTreeHelper.GetChildrenCount(currentStackPanel);
                    for(int j=0; j<numberOfRectangles; j++)
                    {
                        if(VisualTreeHelper.GetChild(currentStackPanel,j).GetType().Equals(typeof(Rectangle)))
                        {
                            Rectangle currentRectangle = VisualTreeHelper.GetChild(currentStackPanel, j) as Rectangle;
                            if (draggedObject != string.Empty && currentRectangle.Name.Equals(draggedObject))
                            {
                                Rectangle newRectangle = new Rectangle();
                                newRectangle.Width = currentRectangle.Width;
                                newRectangle.Height = currentRectangle.Height;
                                newRectangle.Fill = currentRectangle.Fill;
    
                                StackPanelDropArea.Children.Add(newRectangle);
                            }
                        }
                                
                    }
                }
            }
        } */
    }
