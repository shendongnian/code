     private void DisplyOnGrid()
     {
       Dispatcher.Invoke(new Action(()=> 
       {
        Wave.Stroke = Brushes.Yellow;
        Wave.StrokeThickness = 1.25;
        for (int i = 0; i < DisplayGrid.Width; i++)
        {
            Wave.Points.Add(new Point(i, 50));
        }
        DisplayGrid.Children.Add(Wave);
       }
     ))};
