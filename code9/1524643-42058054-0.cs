    while (true)
    {
         Dispatcher.Invoke(new Action(() => { myCanvas.Children.Clear(); }));
         for (int i = 1; i <= 100; i++)
         {
             Dispatcher.Invoke(new Action(() => { myCanvas.Children.Add(myRectangle[i]); }));
         }
    }
