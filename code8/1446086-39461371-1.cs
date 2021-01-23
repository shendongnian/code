        public sealed partial class MainPage : Page,INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            public List<MenuFlyoutItemBase> OptionItems { get; set; }
            public List<MenuFlyoutItemBase> InitFlyoutItems()
            {
                var list = new List<MenuFlyoutItemBase>
                {
                    new MenuFlyoutItem {Text="Start item 1" },
                    new MenuFlyoutItem {Text="Start item 2" },
                    new MenuFlyoutItem {Text="Start item 3" },
                    new MenuFlyoutSubItem { Text="Start Item 4"  }
                };
                ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "Old Sub Item 1" });
                ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "Old Sub Item 2" });
                ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "Old Sub Item 3" });
                ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "Old Sub Item 4" });
                return list;
            }
            public List<MenuFlyoutItemBase> UpdateFlyoutItems()
            {
                var list = new List<MenuFlyoutItemBase>
                {
                    new MenuFlyoutItem {Text="Start item 1" },
                    new MenuFlyoutItem {Text="Start item 2" },
                    new MenuFlyoutItem {Text="Start item 3" },
                    new MenuFlyoutSubItem { Text="Start Item 4"  }
                };
                ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "New Sub Item 1" });
                ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "New Sub Item 2" });
                ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "New Sub Item 3" });
                ((MenuFlyoutSubItem)list[3]).Items.Add(new MenuFlyoutItem { Text = "New Sub Item 4" });
                return list;
            }
            public MainPage()
            {
                this.InitializeComponent();
                DataContext = this;
            }
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                OptionItems = InitFlyoutItems();
                RaiseProperty(nameof(OptionItems));
                base.OnNavigatedTo(e);
            }
        
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                OptionItems=UpdateFlyoutItems();
                RaiseProperty(nameof(OptionItems));
            }
        }
