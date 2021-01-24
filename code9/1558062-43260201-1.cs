	List<string> stirngcolor = new List<string>() { "Blue", "Green", "Red" };//
	Dictionary<string, double> dicoCoeff = new Dictionary<string, double>();
	int coeffValue = 0;
	// Determine the weight of color (by occurrence decending)
	for (int i = stirngcolor.Count; i > 0; i--)
	{
		dicoCoeff.Add(stirngcolor[i - 1], coeffValue++);
	}
	var collection = _database.GetCollection<Artist>(collectionDb);
	var request = from x in collection.AsQueryable()
			  where x.Artworks.Any(child =>
				  child.MostColors.Any(c => stirngcolor.Contains(c.color))
				  )
			  select x;
	List<Artist> artistList = request.ToList();
	#region art
	foreach (Artist artistValue in listPaletet)
	{
		foreach (ArtWork art in artistValue.Artworks)
		{
			double sum = 0;
			for (int ii = 0; ii < art.MostColors.Count; ii++)
			{
				double coeff = 0;
				#region coeff
				if (dicoCoeff.ContainsKey(art.MostColors[ii].color))
				{
					coeff = dicoCoeff[art.MostColors[ii].color];
				}
				#endregion
				sum += art.MostColors[ii].occurrence * coeff;
			}
			art.colorScore = sum;
			artList.Add(art);
		}
	}
	#endregion
