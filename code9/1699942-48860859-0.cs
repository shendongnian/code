    //
    // Build the list of work items for which we want to retrieve more information
    //
    int[] ids = (from WorkItemLinkInfo info in links
                 select info.TargetId).ToArray();
    
    //
    // Next we want to create a new query that will retrieve all the column values from the original query, for
    // each of the work item IDs returned by the original query.
    //
    var detailsWiql = new StringBuilder();
    detailsWiql.AppendLine("SELECT");
    bool first = true;
    
    foreach (FieldDefinition field in treeQuery.DisplayFieldList)
    {
        detailsWiql.Append("    ");
        if (!first)
            detailsWiql.Append(",");
        detailsWiql.AppendLine("[" + field.ReferenceName + "]");
        first = false;
    }
    detailsWiql.AppendLine("FROM WorkItems");
    
    //
    // Get the work item details
    //
    var flatQuery = new Query(_workItemStore, detailsWiql.ToString(), ids);
    WorkItemCollection details = flatQuery.RunQuery();
