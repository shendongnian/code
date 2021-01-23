    SPList oList = SPContext.Current.Web.Lists["ListName"];
    SPQuery query = new SPQuery();
    query.Query = "<OrderBy><FieldRef Name='Name' /></OrderBy>";
    DataTable dtcamltest = oList.GetItems(query).GetDataTable();
    DataView dtview = new DataView(dtcamltest);
    DataTable dtdistinct = dtview.ToTable(true, "Name");
