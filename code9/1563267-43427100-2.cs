        private void HighlightSelection(Line selectedob)
        {
            selectedob.Stroke = Brushes.Red;
        }
        private void UnHighlightSelection()
        {
            //if nothing has been selected yet.
            if (_selectedLine == null) return;
            _selectedLine.Stroke = Brushes.Black;
            _selectedLine = null;
        }
