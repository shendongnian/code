	// isolate the sentences with corresponding sections and line numbers
	var sentences = paragraph
		.Split(separator.Sentences, StringSplitOptions.RemoveEmptyEntries)
		.Select(sentence => sentence.Trim())
		.Select(sentence => new
		{
			Text = sentence,
			Length = sentence.Length,
			Sections = sentence
				   .Split(separator.Sections)
				   .Select((section, index) => new
				   {
					   Index = index,
					   Text = section,
					   Lines = lines
							.Where(line => line.Text.Contains(section))
							.Select(line => line.Number)
				   })
				   .OrderBy(section => section.Index)
		})
		.OrderByDescending(p => p.Length)
		.ToList();
