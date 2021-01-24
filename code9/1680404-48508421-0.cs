    //Create our database connection
    FirestoreDb db = FirestoreDb.Create(projectId);
    
    //Create a query
    CollectionReference collection = db.Collection("cities");
    Query qref = collection.Where("Capital", QueryOperator.Equal, true);
    
    //Listen to realtime updates
    FirebaseDocumentListener listener = qref.AddSnapshotListener();
    
    //Listen to document changes
    listener.DocumentChanged += (obj, e) =>
    {
        var city = e.DocumentSnapshot.Deserialize<City>();
        Console.WriteLine(string.Format("City {0} Changed/Added with pop {1}", city.Name, city.Population));
    };
 
