    async Task DoSomethingAsync()
    {
      using( IWebService web = new WebService( ... ) )
      using( IDatabaseService db = new DatabaseService( ... ) )
      {
        List<Entity> rows = await db.GetRowsAsync( ... );
        foreach( Entity row in rows )
        {
          RelatedInfo info = await web.GetRelatedInfoAsync( row.Foo );
          await web.MakeAnotherServiceCallAsync( row.Bar );
          await db.UpdateEntityAsync( row.Id, info );
        }
      }
    }
