    var sb = new StringBuilder();
    var note = XDocument.Load("test.xml").Root.Descendants();            
    foreach (var el in note)
    {                
        sb.Append(el.Name).Append(": ").AppendLine(el.Value);               
    }
    Console.WriteLine(sb);
