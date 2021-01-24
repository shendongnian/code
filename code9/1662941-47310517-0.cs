    BsonDocument bdoc = new BsonDocument()
    {
        { "three", 3 },
        { "pi", 3.14 },
        { "e", "2.71" },
        { "true", true },
        { "arr", new BsonArray() }
    };
    double three = bdoc["three"].ToDouble();    // three = 3.0
    double pi = bdoc["pi"].ToDouble();       // pi = 3.14
    double e = bdoc["e"].ToDouble();         // e = 2.71
    double t = bdoc["true"].ToDouble(); // throws NotSupportedException
    double arr = bdoc["arr"].ToDouble(); // throws NotSupportedException
