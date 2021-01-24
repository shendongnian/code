        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindowOnLoaded;
        }
        private void MainWindowOnLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MainWindowOnLoaded;
            var oClsModule = new ClsModules();
            var allModules = oClsModule.GetData().Where(x => x.IsActive && x.ModuleCode != 1);
            trvItemGroup.ItemsSource = allModules.ToList();
            foreach (TbModules item in trvItemGroup.Items)
            {
                if (item.ModuleEName.Trim() == "Account")
                {
                    TreeViewItem treeViewItem = (TreeViewItem)trvItemGroup.ItemContainerGenerator.ContainerFromItem(item);
                    treeViewItem.Items.Add("Sub Account");
                }
            }
        }
