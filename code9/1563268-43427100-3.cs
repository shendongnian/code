        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                DeleteLine();
            }
        }
        public void DeleteLine()
        {
            //if nothing has been selected yet.
            if (_selectedLine == null) return;
            //if the selection has been deleted.
            if (!MyCanvas.Children.Contains(_selectedLine)) return;
            UnHighlightSelection();
            MyCanvas.Children.Remove(_selectedLine);
        }
