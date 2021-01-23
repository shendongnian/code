	private void LoadButtonsInformation()
	{
		using (var stream = new MemoryStream(File.ReadAllBytes(@"C:\Projects\info.bin")))
		{
			var serializer = new BinaryFormatter();
			var buttonInformations = (ButtonInformation[]) serializer.Deserialize(stream);
			var buttons= buttonInformations.Select(button => new Button
			{
				Location = new Point(button.X, button.Y),
				Text = button.Text,
				Width = button.Width,
				Height = button.Height
			}).ToArray();
			//add to form
			foreach (var button in buttons)
				Controls.Add(button);
		}
	}
	private void SaveButtonsInformation(params Button[] buttons)
	{
		var buttonsInformation = buttons.Select(button => new ButtonInformation
		{
			X = button.Location.X,
			Y = button.Location.Y,
			Text = button.Text,
			Width = button.Width,
			Height = button.Height
		}).ToArray();
		using (Stream stream = new FileStream(@"C:\Projects\info.bin", FileMode.Create))
		{
			var serializer = new BinaryFormatter();
			serializer.Serialize(stream, buttonsInformation);
		}
	}
	[Serializable]
	public class ButtonInformation
	{
		public int X { get; set; }
		public int Y { get; set; }
		public string Text { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
	}
