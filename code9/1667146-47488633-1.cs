    var inputString = "ñaáme";
	var result = string.Concat(Regex.Replace(inputString, @"(?i)[\p{L}-[ña-z]]+", m => 
			m.Value.Normalize(NormalizationForm.FormD)
		)
		.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
	Console.Write(result);
