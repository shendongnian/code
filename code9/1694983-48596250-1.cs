    var kml = (XNamespace) "http://www.opengis.net/kml/2.2";
    var xdoc = XDocument.Parse(xml); // XDocument.Load(stream or file);
   
    var coordinates = xdoc
       .Descendants(kml + "coordinates") // find coordinates 
       .GroupBy(c => c.Value)           // group by its value
       .Where(c => c.Count() > 1)       // if we found more then one value
       .Select(c=> c);                  // project the item for removal
       
    int totalRecordsRemoved = 0;
    // loop over each key    
    foreach(var coord in coordinates)
    {
      // loop over the double coordinates, skipping the first item
      foreach(var item in coord.Skip(1))
      {
         totalRecordsRemoved++;
         // remove the Placemark node, 
         // assuming there ALWAYS will be a Placemark up the hierachy
         // if not First will bark
         item.Ancestors(kml + "Placemark").First().Remove();
      }
    }
