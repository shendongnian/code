    ViewBag.Items = db.Items.Select(m => new KeyValuePair<string, MyType>
        ( 
            m.Id, 
            new MyType { Column1 = m.Column1, Column2 = m.Column2 }
        )).ToArray();
