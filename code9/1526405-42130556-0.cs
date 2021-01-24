    ...
    SqlDataTagging.InsertCommandType = SqlDataSourceCommandType.StoredProcedure;
    SqlDataTagging.InsertParameters.Clear(); // add this line to clear InsertParameters collection before adding parameters
    SqlDataTagging.InsertParameters.Add("ParentID", e.NewValues["ParentTag_ID"].ToString());
    SqlDataTagging.InsertParameters.Add("TagName", e.NewValues["TagName_VC"].ToString());
    SqlDataTagging.InsertParameters.Add("UserID", "1");
    ...
