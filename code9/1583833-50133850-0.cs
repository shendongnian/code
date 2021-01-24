    using (var database = new Database("connectionstring ...", "ado client name ..."))
    {
        database
           .Query<Movie>()
           .AsDbSet()
           .BulkUpdate(_data);
    }
