    string searchTerm = "quick brown *fox"
    string withOptional = searchTerm.Replace("*", "");
	string withoutOptional = Regex.Replace(searchTerm, "[*]\w", "");
	string[] options = new string[]{ withOptional, withoutOptional }; 
	
	string query = String.Concat(@"
		SELECT *
		FROM FullTextSearches AS FT_TBL ");
	int i = 1;
	List<SqlParameter> parameters = new List<SqlParameter>();
	foreach(string option in options)
	{
		parameters.Add(new SqlParameter("SearchCondition" + (i++).ToString(), "\"" + option + "\""))
		query += $@"LEFT JOIN CONTAINSTABLE(FullTextSearches, (Title, Body), @SearchCondition{i - 1}) AS KEY_TBL{i - 1} ON FT_TBL.Id = KEY_TBL{i - 1}.[KEY] ";
	}
	SqlParameter paramSkip = new SqlParameter("Skip", pageNumber * pageSize);
	SqlParameter paramTake = new SqlParameter("Take", pageSize);
	SqlParameter paramRoles = new SqlParameter("Roles", accessibility);
	object[] parms = new object[parameters.Length + 3];
	for	(j = 0; j < parameters.Length; j++)
	{
		parms[j] = parameters[j];
	}
	parms[parms.Length - 3] = paramSkip;
	parms[parms.Length - 2] = paramTake;
	parms[parms.Length - 1] = paramRoles;
	var results = db.FullTextSearch.SqlQuery(query, parms);
	string query += String.Concat(@"
		WHERE (FT_TBL.Accessibility = 0) OR ((FT_TBL.Accessibility & @Roles) > 0)
		ORDER BY KEY_TBL.[RANK] DESC
		OFFSET (@Skip) ROWS FETCH NEXT (@Take) ROWS ONLY");
