    string[] csvlines = File.ReadAllLines("All_Machines.csv");
        XElement xml = new XElement("data-set",
            from str in csvlines
            let columns = str.Split(',')
            select new XElement("PDA_DATA",
                new XElement("ID", columns[0]),
                new XElement("NODE", columns[1]),
                new XElement("PROCESS_STATE", columns[2]),
                new XElement("TIME_STAMP", columns[3]),
                new XElement("PREV_TIME_STAMP", columns[4]),
                new XElement("CALCULATED", columns[5]),
                                 )   
                                );
        // Remove unneccessray elements
            XElement xml2 = new XElement("data-set",                                       
                    from el in xml.Elements() 
                    where (el.Element("TIME_STAMP").Value != (el.Element("PREV_TIME_STAMP").Value))
                    select el
                    );
           xml2.Elements("PDA_DATA").Elements("TIME_STAMP").Remove();
           xml2.Elements("PDA_DATA").Elements("PREV_PROCESS_STATE").Remove();
           xml2.Elements("PDA_DATA").Elements("CALCULATED").Remove();
           xml2.Save("All_Machines.xml");
