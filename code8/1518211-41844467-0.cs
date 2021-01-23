	for (int i = 0; i < mList.Count; i++)
	{
		m = mList[i];
		//foreach (string value in m.GetGenreList())
		//{
			string all_genres = string.Join(",", m.GetGenreList()); //get all genres as a comma seperated in single string
			Console.WriteLine("{0,-10} {1,-30} {2,-10} {3,-20} {4,-20} {5,-10}", i + 1, m.Title, m.Duration, all_genres, m.Classification, m.openingDate);
		//}
	}
