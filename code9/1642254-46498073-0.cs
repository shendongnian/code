    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("it");
    
    using (var p = new ChoCSVReader("Bosch Luglio 2017.csv")
        .Configure((c) => c.MayContainEOLInData = true) //Handle newline chars in data
        .Configure(c => c.Encoding = Encoding.GetEncoding("iso-8859-1")) //Specify the encoding for reading
        .WithField("CodArt", 1) //first column
        .WithField("Descrizione", 2) //second column
        .WithField("Prezzo", 3, fieldType: typeof(decimal)) //third column
        .Setup(c => c.BeforeRecordLoad += (o, e) =>
        {
            e.Source = e.Source.CastTo<string>().Replace(@"""", String.Empty); //Remove the quotes
        }) //Scrub the data
        )
    {
        var dt = p.AsDataTable();
    
        //foreach (var rec in p)
        //    Console.WriteLine(rec.Prezzo);
    }
