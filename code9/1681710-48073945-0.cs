        public static void OnProcessDrop(object sender, ProcessDropEventArgs<T> e)
        {
            int higherIdx = Math.Max(e.OldIndex, e.NewIndex);
            int lowerIdx = Math.Min(e.OldIndex, e.NewIndex);
            e.ItemsSource.Move(lowerIdx, higherIdx);
            e.ItemsSource.Move(higherIdx - 1, lowerIdx);
            e.Effects = DragDropEffects.Move;
        }
