    string lsInput = @"SITE_ID,HOUSE,STREET,CITY,STATE,ZIP,APARTMENT
    44,545395,PORT ROYAL,CORPUS CHRISTI,TX,78418,2
    44,608646,TEXAS AVE,ODESSA,TX,79762,
    44,487460,EVERHART RD,CORPUS CHRISTI,TX,78413,
    44,275543,EDWARD GARY,SAN MARCOS,TX,78666,4
    44,136811,MAGNOLIA AVE,SAN ANTONIO,TX,78212";
    
    Dictionary<string, string> loValidations = new Dictionary<string, string>();
    loValidations.Add("SITE_ID", @"^\d+$"); //it can only be an integer and it is required.
    //....
    
    bool lbValid = true;
    using (CsvReader loCsvReader = new CsvReader(new StringReader(lsInput), true, ','))
    {
        while (loCsvReader.ReadNextRecord())
        {
            foreach (var loValidationEntry in loValidations)
            {
                if (!Regex.IsMatch(loCsvReader[loValidationEntry.Key], loValidationEntry.Value))
                {
                    lbValid = false;
                    break;
                }
            }
            if (!lbValid)
                break;
        }
    }
    Console.WriteLine($"Valid: {lbValid}");
