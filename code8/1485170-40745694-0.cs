    public void testDraw()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            foreach (Timeline timeLineWin in Application.Current.Windows)
            {
                timeLineWin.setCurrentValues(CurrentIteration);
                timeLineWin.linechart1
                    .HighlightPoint(timeLineWin.currentX, timeLineWin.currentY);
            }
        });
    }
