    var sb = new System.Text.StringBuilder();
    while (reader.Read())
    {
      var id = reader.GetString("id");
      var name = reader.GetString("name");
      var style = name == "test" ? "background-color: #e1e1e1" : "";
      sb.AppendLine("<tr><td id='" + id + "' style='" + style +  "'>" + name + "</td></tr>");
    }
    // use sb.ToString() for the result
