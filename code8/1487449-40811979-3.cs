    @{
        var dataFile = Server.MapPath("~/Files/myFile.txt");
        var ListFromFile= File.ReadAllLines(dataFile);
        StringBuilder sb = new StringBuilder();
        foreach (string line in ListFromFile)
        {
           sb.Append(line + "\n");   
        }
        var str = new HtmlString(sb.ToString());
    }
