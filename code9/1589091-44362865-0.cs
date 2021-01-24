    string input;
    using (var reader = new StreamReader(Request.InputStream)){
    input = reader.ReadToEnd();
    }
    var j = Json.Encode(input); // Your are encoding the data as JSON here
    Response.Write(j);
