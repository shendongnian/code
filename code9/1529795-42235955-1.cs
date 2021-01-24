          List<string> wTextFilter = new List<string>();
            wTextFilter.Add("First");
            wTextFilter.Add("Employee");
            // Get all Id's that satisfy all conditions:            
            List<int> results = dt.AsEnumerable()
                // Get all Id's:
                .Select(dataRow => dataRow.Field<int>("l_id"))
                // Filter the Id's : 
                .Where(id =>
                    // the Id should be greater than one.
                        id > 1   &&
                        // check if all W_Text entries has a record in the datatable with the same Id.
                        wTextFilter.All(W_Text => dt.AsEnumerable().Any(dataRow => dataRow.Field<string>("W_Text") == W_Text && dataRow.Field<int>("l_id") == id)))
                        .Distinct().ToList();
            // Get all datatable rows filtered by the list of Id's.
            DataTable dtCopy = dt.AsEnumerable().Where(dataRow => results.Contains((dataRow.Field<int>("l_id")))).CopyToDataTable();
