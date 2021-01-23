    private void btnSearch_Click(object sender, EventArgs e)
    {
    var client = new MongoClient("mongodb://localhost");
    var database = client.GetDatabase("test");
    var collection = database.GetCollection<MyModel>("users");
    var filter = Builders<BsonDocument>.Filter.Eq("Name", txtName.Text);
    var results = collection.Find(filter).ToList();
    IEnumerable<User> allUsers = BsonSerializer.Deserialize<IEnumerable<User>>(result);
    dgvAll.DataSource = allUsers;
    dgvAll.DataBind();
    }
