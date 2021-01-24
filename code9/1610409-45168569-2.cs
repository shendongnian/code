    async Task DoSomethingAsync()
    {
      using( IWebService web = new WebService( ... ) )
      using( IDatabaseService db = new DatabaseService( ... ) )
      {
        List<Entity> rows = await db.GetRowsAsync( ... );
        var tasks = rows.Select(async row =>
        {
          RelatedInfo info = await web.GetRelatedInfoAsync( row.Foo );
          await web.MakeAnotherServiceCallAsync( row.Bar );
          return info;
        });
        var infos = await Task.WhenAll(tasks);
        for ( int i = 0; i != rows.Count; ++i )
          await db.UpdateEntityAsync( rows[i].Id, infos[i] );
      }
    }
