    <?xml version="1.0" encoding="utf-8" ?>
    <config>
     <Cars>
      <SuvConfigFilename>this_path_is_1</SuvConfigFilename>
      <SedanConfigFilename>this_path_is_2</SedanConfigFilename>
     </Cars>
    </config>
    
    XDocument centralConfig = 
    XDocument.Load("C:\\Users\\1234\\Documents\\Visual Studio 
    2013\\Projects\\testStructs\\testStructs\\CentralConfig.xml");
        var query = from c in centralConfig.Descendants("Cars")
                    select c;
        Console.WriteLine("----------------------start");
        foreach (XElement a in query)
        {         
         Console.WriteLine(a.Element("SuvConfigFilename").Value.ToString());          
         Console.WriteLine(a.Element("SedanConfigFilename").Value.ToString());
        }
         Console.WriteLine("----------------------end");
