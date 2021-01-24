    static void Main(string[] args) {
        var instanceField = typeof(BsonDocumentSerializer).GetField("__instance", BindingFlags.Static | BindingFlags.NonPublic);
        instanceField.SetValue(null, new AlwaysAllowDuplicateNamesBsonDocumentSerializer());
        TestMongoQuery();
        Console.ReadKey();
    }
    static async void TestMongoQuery() {
        var client = new MongoClient();
        var db = client.GetDatabase("Test_DB");            
        var collection = db.GetCollection<BsonDocument>("TestTable");
        using (var allDocs = await collection.FindAsync(FilterDefinition<BsonDocument>.Empty)) {
            while (allDocs.MoveNext()) {
                foreach (var doc in allDocs.Current) {
                    var duplicateElements = doc.Elements.Where(c => c.Name == "DuplicateCol");
                    foreach (var el in duplicateElements) {
                        Console.WriteLine(el.Name + ":" + el.Value);
                    }
                }
            }
        }
    }
