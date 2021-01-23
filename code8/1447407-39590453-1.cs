            private void FlipViewItem_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (e.Delta.Translation.X != 0)
            {
                e.Handled = true;
            }
        }
