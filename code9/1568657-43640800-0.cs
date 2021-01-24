    mainWindow.Loaded += (sender, args) =>
            {
                // I couldn't find a proper place to put this. 
                // I need an event after 100% of all setup is completed
                var timer = new DispatcherTimer()
                {
                    Interval = TimeSpan.FromSeconds(3)
                };
                timer.Tick += (s, e) =>
                {
                    DockingManagerDeserialize(mainWindow);
                    timer.Stop();
                };
                timer.Start();
            };
