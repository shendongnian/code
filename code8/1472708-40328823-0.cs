    public IHttpActionResult GetEntitySomeEntityType(ODataQueryOptions<EntityPMDVendorLookup> queryOptions)
    {
        // validate the query.
        try
        {
            queryOptions.Validate(_validationSettings);
        }
        catch (ODataException ex)
        {
            return BadRequest(ex.Message);
        }
        SQLODataBuilder<SomeEntityType, SomeEntityType_Column> SQLBuilder;
        SQLBuilder = new SQLODataBuilder<Models.PMD.Lookup.SomeEntityType, Models.PMD.Lookup.SomeEntityType_Column>(queryOptions, SomeEntityType_Column.VendorNumber, true);
        SQLBuilder.DefaultSortColumn = SomeEntityType_Column.VendorNumber;
        SQLBuilder.DefaultSortAscending = true;
        SQLBuilder.UseSelectDistinct = true;
        List<SomeEntityType> ResultList;
        ResultList = new List<Models.PMD.Lookup.SomeEntityType>();
        ResultList = SQLBuilder.ExecuteQuery(@"TableName", System.Configuration.ConfigurationManager.ConnectionStrings[@"ConnectionStringName"].ConnectionString);
        return Ok<IEnumerable<SomeEntityType>>(ResultList);
    }
