    string[] words = { "First", "Employee" }; 
    int iId = dtResult.Columns.IndexOf("l_id");
    int iText = dtResult.Columns.IndexOf("W_Text");
    var iRows = dtResult.Rows.Cast<DataRow>(); 
    var idGroups = iRows.ToLookup(r => (int)r[iId]);    // group by id
    var result = idGroups.Where(g => !words.Except(g.Select(r => r[iText] as string)).Any());
    var dtCopy = result.SelectMany(g => g).CopyToDataTable();
