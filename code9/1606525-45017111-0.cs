            var curr = ApplicationView.GetForCurrentView();
            if (curr.IsFullScreenMode == true)
            {
                ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
                curr.FullScreenSystemOverlayMode = FullScreenSystemOverlayMode.Minimal;
            }
            else
            {
                ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.Auto;
                curr.FullScreenSystemOverlayMode = FullScreenSystemOverlayMode.Standard;
            }
