    var ds = new DataSet();
    var xml = XElement.Load("test.xml");
    var cars = xml.Elements().GroupBy(elem => elem.Name, elem => elem.Elements());
    foreach (var car in cars)
    {
        var dt = new DataTable(car.Key.LocalName);
        foreach (var elem in car.First())
        {
            dt.Columns.Add(elem.Attribute("Name").Value,
                Type.GetType(elem.Attribute("Valuetype").Value));
        }
        foreach (var elem in car)
        {
            dt.Rows.Add(elem.Select(x => x.Value).ToArray());
        }
        ds.Tables.Add(dt);
    }
