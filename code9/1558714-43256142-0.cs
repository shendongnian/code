    List<Row> rows = GetRows();
    int i =0;
    List<Document> docs = rows.Select(r => new Document(){ Id = (i++).ToString(), PubId = r.fields.Where(f => f.Name == "PubId").FirstOrDefault(), Date = GetDate(r.fields.Where(f => f.Name == "Date").FirstOrDefault()) }).ToList();
    public Date GetDate(string input)
    {
      // Convert Here.
    }
