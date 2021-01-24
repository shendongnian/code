            public SomeView()
            {
                SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            }
    
            private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
            {
                // Refreshes UI
                var dataContext = DataContext;
                DataContext = null;
                DataContext = dataContext;
            }
