    var dynamicParameters = new DynamicParameters();
    dynamicParameters.Add("@MyObjects", lst
        .AsTableValuedParameter("dbo.tvMyObjects", new[] 
        {
            "ID" ,
            "ObjectType",
            "Content", 
            "PreviewContent"
        }));
    connection.Connection.Execute(@"
        INSERT INTO [MyObject] (Id, ObjectType, Content, PreviewContent) 
        SELECT Id,
               ObjectType,
               Content,
               PreviewContent
        FROM   @MyObjects", dynamicParameters);
