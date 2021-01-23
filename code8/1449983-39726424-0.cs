    private GridViewTemplate CreateChildTemplate()
    {
        GridViewTemplate childTemplate = new GridViewTemplate();
        GridViewTextBoxColumn column = new GridViewTextBoxColumn("WID");
        childTemplate.Columns.Add(column);
        column = new GridViewTextBoxColumn("Name");
        childTemplate.Columns.Add(column);
        childTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
        return childTemplate;
    }
    private GridViewTemplate CreateGrandChildTemplate()
    {
        GridViewTemplate grandChildTemplate = new GridViewTemplate();
        GridViewTextBoxColumn column = new GridViewTextBoxColumn("Name");
        grandChildTemplate .Columns.Add(column);
        grandChildTemplate .AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
        return grandChildTemplate ;
    }
    private void RadForm1_Load(object sender, EventArgs e)
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("test");
        var collectionWatchtbl = database.GetCollection<BsonDocument>("UserWatchtbl");
        var filter = new BsonDocument();
        var user = new List<UserWatchTblCls>();
        var cursor = collectionWatchtbl.FindAsync(filter).Result;
        cursor.ForEachAsync(batch =>
        {
            user.Add(BsonSerializer.Deserialize<UserWatchTblCls>(batch));
        });
        this.radGridView1.DataSource = user;
        this.radGridView1.Columns["fbId"].IsVisible = false;
        this.radGridView1.Columns["Pass"].IsVisible = false;
        GridViewTemplate childTemplate = CreateChildTemplate();
        childTemplate.DataSource = new BindingSource(user, "WatchTbls");
        GridViewTemplate grandChildTemplate = CreateGrandChildTemplate();
        grandChildTemplate.DataSource = new BindingSource(childTemplate.DataSource, "Symbols");
        this.radGridView1.Templates.Add(childTemplate);
        childTemplate.Templates.Add(grandChildTemplate);
        var gridViewRelation1 = new GridViewRelation(radGridView1.MasterTemplate, childTemplate);
        this.radGridView1.Relations.Add(gridViewRelation1);
        var gridViewRelation2 = new GridViewRelation(childTemplate, grandChildTemplate);
        this.radGridView1.Relations.Add(gridViewRelation2);
    }
    public class UserWatchTblCls
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public string fbId { get; set; }
        public string Name { get; set; }
        [BsonElement("pass")]
        public string Pass { get; set; }
        [BsonElement("Watchtbl")]
        public List<WatchTblCls> WatchTbls { get; set; }
    }
    public class WatchTblCls
    {
        [BsonElement("wid")]
        public string WID { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("Symboles")]
        public List<SymboleCls> Symbols { get; set; }
    }
    public class SymboleCls
    {
        public string Name { get; set; }
    }
