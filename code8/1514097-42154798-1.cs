    var myEntityBulk = new BulkInsert<MyEntity>(
        _mYConnectionString,
         "MyEntities", 
          myEntities, 
          new[] { "ObjectState","NavigationPropertyOne", "NavigationPropertyTwo" }
    );
    myEntityBulk.Insert();
