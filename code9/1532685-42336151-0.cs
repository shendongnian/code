	public DateTime? GetDateTakenFromBitmap(string bitmapFileName)
	{
		using (var bm = System.Drawing.Bitmap.FromFile(bitmapFileName))
		{
			return
				bm
					.PropertyItems
					.Where(x => x.Id == 0x9003)
					.Select(x =>
					{
						DateTime dt;
						var enc = new ASCIIEncoding();
						var parsed = DateTime.TryParseExact(
							enc.GetString(x.Value, 0, x.Len - 1),
							"yyyy:MM:dd HH:mm:ss",
			    			CultureInfo.CurrentCulture,
							DateTimeStyles.None,
							out dt);
						return parsed ? (DateTime?)dt : null;
					})
					.FirstOrDefault();
	    }
	}
