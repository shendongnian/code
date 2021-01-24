        private Line _selectedLine;
        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            object testPanelOrUi = InputHitTest(e.GetPosition(this)) as FrameworkElement;
            // if the selection equals _selectedLine, i.e. the line has been selected already
            if (Equals(testPanelOrUi, _selectedLine)) return;
            // The selection is different.
            // if _selectedLine is not null, revert color change.
            if (_selectedLine != null)
            {
                UnHighlightSelection();
            }
            // if testPanelOrUi is not a line.
            if (!(testPanelOrUi is Line)) return;
            // The selection is different and is a line.
            _selectedLine = (Line) testPanelOrUi;
            HighlightSelection(_selectedLine);
        }
