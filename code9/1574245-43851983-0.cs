    public class MyDataGrid : DataGrid
    {
        static MyDataGrid()
        {
            EventManager.RegisterClassHandler(typeof(DataGridCell), UIElement.PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(PreviewMouseLeftButtonDownHandler));
            EventManager.RegisterClassHandler(typeof(DataGridCell), UIElement.MouseLeftButtonUpEvent, new MouseButtonEventHandler(MouseLeftButtonUpHandler), true);
            EventManager.RegisterClassHandler(typeof(DataGridCell), UIElement.MouseMoveEvent, new MouseEventHandler(MouseMoveHandler), true);
        }
        private static bool restoreNextCells = false;
        private static bool isSelectedCell = false;
        private static void PreviewMouseLeftButtonDownHandler(object sender, MouseButtonEventArgs e)
        {
            var cell = sender as DataGridCell;
            isSelectedCell = cell.IsSelected;
            restoreNextCells = cell.IsSelected && Keyboard.Modifiers == ModifierKeys.None;
        }
        private static void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            var cell = sender as DataGridCell;
            if (isSelectedCell && e.LeftButton == MouseButtonState.Pressed && cell.IsSelected && Keyboard.Modifiers == ModifierKeys.None)
            {
                DragDrop.DoDragDrop(cell, new ObjectDataProvider(), DragDropEffects.All);
            }
            restoreNextCells = false;
            isSelectedCell = false;
        }
        private static void MouseLeftButtonUpHandler(object sender, MouseButtonEventArgs e)
        {
            restoreNextCells = false;
            isSelectedCell = false;
        }
        protected override void OnSelectedCellsChanged(SelectedCellsChangedEventArgs e)
        {
            if (restoreNextCells && e.RemovedCells.Count > 0)
            {
                foreach (DataGridCellInfo item in e.RemovedCells)
                {
                    SelectedCells.Add(item);
                }
                restoreNextCells = false;
            }
            base.OnSelectedCellsChanged(e);
        }
    }
