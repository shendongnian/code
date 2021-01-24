    XDocument doc = XDocument.Load("");
    var values = doc.Descendants("settingB");
    foreach( var value in values )
      {
         Console.WriteLine( value.Value );
      }
    Console.ReadLine();
