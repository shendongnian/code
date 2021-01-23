	var options = new PHFetchOptions();
	options.Predicate = NSPredicate.FromFormat(string.Format("((mediaSubtype & {0}) == {0})", (int)PHAssetMediaSubtype.PhotoHDR)); 
	var fetchResults = PHAsset.FetchAssets(PHAssetMediaType.Image, options);
	foreach (var item in fetchResults)
	{
		Console.WriteLine((item as PHAsset).MediaSubtypes);
	}
