	List<string> values = new List<string> { "1", "2", "3", "4" };
	var matchingInstitutesNames = context
		.Tbl_Institute
		.Where(x => values.Contains(x.Institute_Id.ToString()))
		.Select(x => x.Institute_Title)
		.ToList();
	var joinedInstitutesNames = string.Joint(",", matchingInstitutesNames);
	user.Company += joinedInstitutesNames;
