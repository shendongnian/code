        public static void OnProcessDrop(object sender, ProcessDropEventArgs<T> e)
        {
            e.ItemsSource.Move(e.OldIndex, e.NewIndex);
            e.Effects = DragDropEffects.Move;
        }
