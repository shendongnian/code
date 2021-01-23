    private void MoveGridUp(double heightToShow)
        {
            double gridHeight = GridContent.ActualHeight;
            Thickness margin = GridContent.Margin;
            margin.Top = heightToShow - gridHeight;
            GridContent.Margin = margin;
        }
