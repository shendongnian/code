    var client = new MongoClient();
    var db = client.GetDatabase("test");
    var collection = db.GetCollection<MetaCorp>("metacorp");
    var m = collection.SingleOrDefault(x => x.Movie_Name == "Hemin"); // Assuming 0 or 1 with that name. Use Where otherwise
    var movieName = "Not found";
    if(movieName != null)
       movieName = m.Movie_Name;
