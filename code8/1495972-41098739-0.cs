        public MainWindow()
        {
            InitializeComponent();
            List<User> items = new List<User>();
            items.Add(new User() { Name = "John Doe", Age = 42, Sex = SexType.Male });
            items.Add(new User() { Name = "Jane Doe", Age = 39, Sex = SexType.Female });
            items.Add(new User() { Name = "Sammy Doe", Age = 13, Sex = SexType.Male });
            var result =
                from x in items
                group x by x.Sex into g
                orderby g.Key
                select g;
            listBox.ItemsSource = result;
        }
----------
       <ListBox x:Name="listBox">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Expander Header="{Binding Key}">
                        <ListBox ItemsSource="{Binding}">
                            <ListBox.ItemTemplate>
                                <DataTemplate>
                                    <StackPanel>
                                        <TextBlock Text="{Binding Name}"/>
                                    </StackPanel>
                                </DataTemplate>
                            </ListBox.ItemTemplate>
                        </ListBox>
                    </Expander>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
