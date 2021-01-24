	private string GeneratePyramid(int number, int pyramidHeight)
	{
		return string.Concat(Enumerable.Repeat(true, pyramidHeight).Select((n, i) => {
			return string.Concat(Enumerable.Repeat(number, i + 1)) +
				Environment.NewLine;
		}).Reverse());
	}
