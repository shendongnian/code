    BlankClass test = new BlankClass();
    string json = "";
    if (myReader.Read())
    {
          test.Thing1 = (int)myReader[0];
          test.Thing2 = (bool)myReader[1];
          test.Thing3 = (string)myReader[2];
          test.Thing4 = (Datetime?)myReader[3];
          json = JsonConvert.SerializeObject(test, Formatting.Indented);
     }
     
     class BlankClass
     {
          int Thing1 { get; set; }
          bool Thing2 { get; set; }
          string Thing3 { get; set; }
          DateTime? Thing4 { get; set; }
     }
