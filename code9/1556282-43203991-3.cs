    var escape = new Func<bool>(() =>
    {
      if (DisplayMode == SplitViewDisplayMode.CompactOverlay
          || DisplayMode == SplitViewDisplayMode.Overlay)
            IsOpen = false;
        if (Equals(ShellSplitView.PanePlacement, SplitViewPanePlacement.Left))
         {
              ShellSplitView.Content.RenderTransform = new TranslateTransform { X = 48 + ShellSplitView.OpenPaneLength };
               focus(FocusNavigationDirection.Right);
               ShellSplitView.Content.RenderTransform = null;
             }
                 else
            {
               ShellSplitView.Content.RenderTransform = new TranslateTransform { X = -48 - ShellSplitView.OpenPaneLength };
               focus(FocusNavigationDirection.Left);
               ShellSplitView.Content.RenderTransform = null;
           }
         return true;
    });
