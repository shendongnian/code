    void Window1_Loaded(object sender, RoutedEventArgs e)
         {
             this.DragSource.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(DragSource_PreviewMouseLeftButtonDown);
             this.DragSource.PreviewMouseMove += new MouseEventHandler(DragSource_PreviewMouseMove);
         }
