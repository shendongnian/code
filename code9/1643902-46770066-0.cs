    //get all directories from basepath 
           string[] filesindirectory = Directory.GetDirectories(basePath);
    
    
          //Loop through each parent directory and get each matching xml file from it
             List<string[]> newList = filesindirectory.Select(folder => (from item in Directory.GetDirectories(folder, "meta", SearchOption.AllDirectories)
                             .Select(item => Directory.GetFiles(item, "*.xml"))
                             .ToList()
                             .SelectMany(x => x)
                         let sx = Directory.GetDirectories(folder, "xml", SearchOption.AllDirectories)
                             .Select(items => Directory.GetFiles(items, "*.xml"))
                             .ToList()
                             .SelectMany(s => s)
                             .Any(s => Path.GetFileName(s) == Path.GetFileName(item))
                         where sx
                         select item).ToArray()
                     .Concat((from xmlItem in Directory.GetDirectories(folder, "xml", SearchOption.AllDirectories)
                             .Select(item => Directory.GetFiles(item, "*.xml"))
                             .ToList()
                             .SelectMany(xs => xs)
                         let sx = Directory.GetDirectories(folder, "meta", SearchOption.AllDirectories)
                             .Select(items => Directory.GetFiles(items, "*.xml"))
                             .ToList()
                             .SelectMany(sc => sc)
                             .Any(sc => Path.GetFileName(sc) == Path.GetFileName(xmlItem))
                         where sx
                         select xmlItem).ToArray()))
                 .Select(xmlFiles => xmlFiles.ToArray()).ToList();
    
    
             //loop through each element of the jagged array
             foreach (string[] path in newList)
             {
                 for (int j = 0; j < path.Length / 2; j++)
                 {
                     XDocument doc = Xdocument.Load(path[j]);
                     string name = doc.Root.Element("Emp").Element("lbl").Value;
                     XDocument doc2 = Xdocument.Load(path[(path.Length / 2) + j]);
                     doc2.Root.Element("Employee").SetElementValue("label", name);
                     doc2.Save(path[(path.Length / 2) + j]);
                 }
             }
