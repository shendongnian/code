    string DataPLevantamento = "30 de outubro de 2016";
		var provider = new System.Globalization.CultureInfo("pt-PT"); 
		string result = DateTime.ParseExact(DataPLevantamento,
							"d' de 'MMMM' de 'yyyy",
							provider,
							System.Globalization.DateTimeStyles.None).ToString();
		Console.WriteLine(result);
