	StringBuilder jsonReturn = new StringBuilder();
	await Task.Run(() =>
	{
		jsonReturn.Append("{");
		for (int i = 0; i < apps.Count(); i++)
		{
			jsonReturn.Append("fooBar");
		}
		jsonReturn.Append("}");
	});
	return jsonReturn.ToString();
