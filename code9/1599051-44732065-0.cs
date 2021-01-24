    private void loopThroughArray()
    {
       var serializer = new JavaScriptSerializer();
       var json = new System.Text.StringBuilder();
       for (int i = 0; i < array.Count; i++)
       {
          MyObject t = array[i];
          json.Append(serializer.Serialize(t));
          if (i < array.Count)
             json.Append(",");
       }
       System.IO.File.WriteAllText(@"<MyFilepath>\json.txt", "{\"json\":[" + json.ToString() + "]}");
    }
