    public void testDraw()
    {
        Application.Current.Dispatcher.Invoke(new Action(() =>
        {
            foreach (Timeline timeLineWin in Application.Current.Windows)
            {
                timeLineWin.setCurrentValues(CurrentIteration);
                timeLineWin.linechart1
                    .HighlightPoint(timeLineWin.currentX, timeLineWin.currentY);
            }
        }));
    }
