     public List<Form> GetFromDetails()
    {
        var DB = new Database();
        var collection = DB.GetCollection<Form>();
        var query = new QueryBuilder<Form>();
        var queryLst = new List<IMongoQuery>();
        // {
        //  "FormId":"1",
        //  "Status":true,
        //  "Version":1
        //};
        //{
        //  "FormId":"1",
        //  "Status":true,
        //  "Version":2
        //};
        List<Form> finalResult = new List<Form>();
        finalResult = collection.FindAll().Where(x => x.Status == true).ToList(); // pasing id 1
        // {
        //  "FormId":"1",
        //  "Status":true,
        //  "Version":1
        //};
        //{
        //  "FormId":"1",
        //  "Status":true,
        //  "Version":2
        //};
        var finalResults = finalResult.Select(n => new Form
        {
            FormId = n.FormId,
            Status = n.Status,
            Version = finalResult.OrderByDescending(v => v.Version).First().Version
        });
        // {
        //  "FormId":"1",
        //  "Status":true,
        //  "Version":2
        //};
        //{
        //  "FormId":"1",
        //  "Status":true,
        //  "Version":2
        //};
        DB.Dispose();
        return finalResult;
    }
