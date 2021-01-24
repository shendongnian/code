    Stream stream = await Request.Content.ReadAsStreamAsync();
    StreamReader sr = new StreamReader(stream);
    var csv = new CsvReader(sr);
    csv.Configuration.Delimiter = ";";
    var records = csv.GetRecords<CRIContactModel>();
    foreach(var record in records) {
        var contact = _criContactService.FindAsync(x => x.ID == record.ID);
        if (contact != null) {
            _criContactService.Update(record, record.ID);
        }
        else {
            _criContactService.Add(record);
        }
    }
