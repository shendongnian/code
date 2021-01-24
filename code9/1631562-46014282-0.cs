	byte[] img = null;
	var tapImage = new TapGestureRecognizer();
	tapImage.Tapped += tapImage_Tapped;
	image.GestureRecognizers.Add(tapImage);
	private async void tapImage_Tapped(object sender, EventArgs e)
	{
		using (var memoryStream = new MemoryStream())
		{
			file.GetStream().CopyTo(memoryStream);
			file.Dispose();
			img = memoryStream.ToArray();
			memoryStream.Dispose();
		}
	}
	private void Insert(object sender, EventArgs e)
	{
		if(img != null)
		{
			var options = new InformationTable
			{
				Id = Guid.NewGuid().ToString(),
				Quantity = TxtQuantity.Text,
				Issue = Ccheck.Checked.ToString(),
				Info = TxtInfo.Text,
				image = Convert.ToBase64String(img),
			};
			_connection.Insert(options);
		}
	}
