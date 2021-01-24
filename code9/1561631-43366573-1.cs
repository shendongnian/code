    var elements = xdoc.Element("root").Elements("record")
                .Select(e => new RecordViewModel
                                 {
                                     Number = e.Element("Object_Number").Value,
                                     Level = e.Element("Object_Level").Value,
                                     Heading = e.Element("Object_Heading").Value,
                                     Milestones = e.Element("Milestones").Value,
                });
    var bs = new BindingSource 
    { 
        DataSource = elements
    };
    
    dgvDoors.DataSource = bs;
