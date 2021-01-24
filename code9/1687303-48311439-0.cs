    FirestoreDb db = FirestoreDb.Create(projectId);
    
    // Create a document with a random ID in the "users" collection.
    CollectionReference collection = db.Collection("users");
    DocumentReference document = await collection.AddAsync(new { Name = new { First = "Ada", Last = "Lovelace" }, Born = 1815 });
    
    // A DocumentReference doesn't contain the data - it's just a path.
    // Let's fetch the current document.
    DocumentSnapshot snapshot = await document.SnapshotAsync();
    
    // We can access individual fields by dot-separated path
    Console.WriteLine(snapshot.GetField<string>("Name.First"));
    Console.WriteLine(snapshot.GetField<string>("Name.Last"));
    Console.WriteLine(snapshot.GetField<int>("Born"));
    
    // Or deserialize the whole document into a dictionary
    Dictionary<string, object> data = snapshot.ToDictionary();
    Dictionary<string, object> name = (Dictionary<string, object>) data["Name"];
    Console.WriteLine(name["First"]);
    Console.WriteLine(name["Last"]);
    
    // See the "data model" guide for more options for data handling.
    
    // Query the collection for all documents where doc.Born < 1900.
    Query query = collection.Where("Born", QueryOperator.LessThan, 1900);
    QuerySnapshot querySnapshot = await query.SnapshotAsync();
    foreach (DocumentSnapshot queryResult in querySnapshot.Documents)
    {
        string firstName = queryResult.GetField<string>("Name.First");
        string lastName = queryResult.GetField<string>("Name.Last");
        int born = queryResult.GetField<int>("Born");
        Console.WriteLine($"{firstName} {lastName}; born {born}");
    }
