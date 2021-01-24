    private void TabControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            ContentPresenter cp =
                tabControl.Template.FindName("PART_SelectedContentHost", tabControl) as ContentPresenter;
            var db = tabControl.ContentTemplate.FindName("TheDrawingBoard", cp) as DrawingBoard;
            CurrentlySelectedDrawingBoard = db;
        }
