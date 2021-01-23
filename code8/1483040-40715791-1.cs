     public MainWindow()
        {
            var model=new MainViewModel(loadGrid);
            DataContext = model;
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
        void loadGrid(IList<LanguagePanelViewModel> panels)
        {
            if (panels == null || !panels.Any())
                return;
            for (int i = 0; i < panels.Count; i++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)});
                var panel = new LanguagePanel { DataContext = panels[i] };
                Grid.SetColumn(panel, i);
                mainGrid.Children.Add(panel);
            }
        }
