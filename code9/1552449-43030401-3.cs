	var question = null;
    foreach (string line in File.ReadLines(filePath))
    {
        if (line.StartsWith("*"))
		{
			if (question!= null) 
			{
				// We have a previous question
				questionList.Add(question);
			}
			question = new QuestionAndTerms();
			question.Question = line.Substring(1);
		}
		if (!string.IsNullOrWhiteSpace(line))
		{
			question.Terms.Add(line);
		}
    }
