     public class group
        {
            public string groupname { get; set; }
            public string CLgroup { get; set; }
            public string displayname { get; set; }
        }
        public Window4()
        {
            InitializeComponent();
            ObservableCollection<group> samdata = new ObservableCollection<group>
            {
                new group{groupname="Group1",CLgroup="xxx",displayname="demo1"},
                new group{groupname="Group1",CLgroup="yyy",displayname="demo2"},
                new group{groupname="Group1",CLgroup="yyy",displayname="demo2"},
            };          
            ListCollectionView collection = new ListCollectionView(samdata);
            collection.GroupDescriptions.Add(new PropertyGroupDescription("groupname"));
            dgdata.ItemsSource = collection;
        }
