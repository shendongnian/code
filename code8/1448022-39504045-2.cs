    var lines = new List<string>();
    var file = new System.IO.StreamReader("c:\\registros.csv");
    while((var line = file.ReadLine()) != null)
    {
       lines.Add(line);
    }
    file.Close();
