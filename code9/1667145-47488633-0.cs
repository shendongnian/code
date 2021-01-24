    var inputString = "ñaáme";
	var result = string.Concat(Regex.Replace(inputString, @"[\p{L}-[ña-zA-Z]]", m => 
			m.Value.Normalize(NormalizationForm.FormD)
		)
		.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
	Console.Write(result);
