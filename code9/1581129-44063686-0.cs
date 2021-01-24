    [AcceptVerbs("PATCH", "MERGE")]
    public IHttpActionResult Patch([FromODataUri] int key, Delta<Product> delta, ODataQueryOptions<Product> options) {
        var existingEntity = //Code to get existing entity by ID, 404 if not found
        byte[] requestETag = options.IfMatch["RowVersion"] as byte[];
        if(!requestETag.SequanceEqual(existingEntity.RowVersion)) { //Simplified if-statement, also do null-checks and such
            // ETags don't match, return HTTP 412
            return StatusCode(HttpStatusCode.PreconditionFailed);
        } else {
            // The ETags match, implement code here to update your entity
            // You can use the 'Delta<Product> delta' parameter to get the changes and use the 'Validate' function here
            // ...
