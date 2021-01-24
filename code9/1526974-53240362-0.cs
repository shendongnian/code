    var csv = new CsvReader(streamReader, false);
    var classMap = csv.Configuration.AutoMap<Row>(); // ClassMap creation
    
    // My price data has dollar signs so those need to be stripped out before parsing to a decimal
    classMap.Map(row => row.Price).ConvertUsing(row => decimal.Parse(row.GetField("Price").Replace("$", "")));
    
    // CsvHelper doesn't support URIs so that requires help as well
    classMap.Map(row => row.Source).ConvertUsing(row => new Uri(row.GetField("Source")));
    
    var prices = csv.GetRecords<Row>();
    
    
    
    // my DTO
    class Row
    {
    	public decimal Price { get; set; }
    	public string ManufacturerSku { get; set; }
    	public string Manufacturer { get; set; }
    	public Uri Source { get; set; }
    	public DateTimeOffset Extraction_Time { get; set; }
    }
