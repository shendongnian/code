    public  void  DrawMissingLines(ObservableCollection<LineBindingPointsClass> lines, double missingLines, Point from, Point to ,int gg)
            {
                if (missingLines > 0)
                {
                    for (int ii = 0; ii < missingLines; ii++)
                    {
                        
                        lines.Add(new LineBindingPointsClass() { From = from , To = to });
                        if (gg == 1)
                        {
                            from.X += 25;
                            to.X += 25;
                        }
                        else if (gg == 2)
                        {
                            from.Y += 25;
                            to.Y += 25;
                        }
                       
                    }
                }
                else if (missingLines < 0)
                {
                    for (int ii = 0; ii < -missingLines; ii++)
                    {                    
                            lines.Remove(lines.Last());                    
                    }
                }
            }
 ----------------------------------------------------------
    private void MyCanvas01_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                Canvas SizedCanvas = (Canvas)sender;
                double missingVerticalLines, MissingHorizontalLines;
    
                missingVerticalLines = (Math.Floor(SizedCanvas.Width) -  VerticalLines.Count() * 25 ) / 25;
                MissingHorizontalLines = (Math.Floor(SizedCanvas.Height) - HorizontalLines.Count() * 25) / 25;
                DrawMissingLines(VerticalLines, missingVerticalLines, 
                    new Point(VerticalLines.Count()*25  , 0),
                    new Point(VerticalLines.Count() * 25 , SizedCanvas.Height ),1);
    
                DrawMissingLines(HorizontalLines, MissingHorizontalLines
                    , new Point(0,HorizontalLines.Count() * 25 ),                
                    new Point( SizedCanvas.Width, HorizontalLines.Count() * 25) ,2);
            }
