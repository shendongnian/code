    public MainPage()
        {
            this.InitializeComponent();
            listview.ItemTemplate = listViewItemTemplate;
            for (int x = 0; x < 10; x++)
            {
                listview.Items.Add("Item " + x);
            }
        }
