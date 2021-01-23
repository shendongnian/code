    private readonly IMongoCollection<BsonDocument> collectionWatchtbl;
    public MainWindow()
    {
        InitializeComponent();
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("test");
        collectionWatchtbl = database.GetCollection<BsonDocument>("UserWatchtbl");
        var filter = new BsonDocument();
        var user = new List<UserWatchTblCls>();
        var cursor = collectionWatchtbl.FindAsync(filter).Result;
        cursor.ForEachAsync(batch =>
        {
            user.Add(BsonSerializer.Deserialize<UserWatchTblCls>(batch));
        });
        // in the UsersComboBox don't forget to set the DisplayMemberPath eqvivalent of Winforms to Name
        UsersComboBox.ItemsSource = user.Select(x => x.Id);
        SymbolesListBox.ItemsSource =
            user.SelectMany(x => x.WatchTbls).SelectMany(y => y.Symbols);
    }
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var document = new BsonDocument();
        BsonArray arrSym = new BsonArray();
        BsonArray arrWatc = new BsonArray();
        document.Add("wid", WIDTextBox.Text.ToString());
        document.Add("name", NameComboBox.SelectedItem.ToString());
        foreach (SymboleCls item in SymbolesListBox.SelectedItems)
        {
            arrSym.Add(new BsonDocument("Name", item.Name));
        }
        document.Add("Symboles", arrSym);
        arrWatc.Add(document);
        // Do You really need to use async?
        collectionWatchtbl.UpdateOne(Builders<BsonDocument>.Filter.Eq("_id", UsersComboBox.SelectedItem), Builders<BsonDocument>.Update.AddToSet("Watchtbl", document));
    }
