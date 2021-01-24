    void DoSomething()
    {
      using( IWebService web = new WebService( ... ) )
      using( IDatabaseService db = new DatabaseService( ... ) )
      {
        List<Entity> rows = db.GetRows( ... );
        foreach( Entity row in rows )
        {
          RelatedInfo info = web.GetRelatedInfo( row.Foo );
          web.MakeAnotherServiceCall( row.Bar );
          db.UpdateEntity( row.Id, info );
        }
      }
    }
