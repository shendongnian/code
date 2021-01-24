	private static Dictionary<string, System.Drawing.Image> _shaded = new Dictionary<string, System.Drawing.Image>()
	{
		{ "0000", WindowsFormsApplication5.Properties.Resources.S0000 },
		{ "0001", WindowsFormsApplication5.Properties.Resources.S0001 },
		//etc
		{ "1100", WindowsFormsApplication5.Properties.Resources.S1101 },
	};
	
	private static Dictionary<string, System.Drawing.Image> _unshaded = new Dictionary<string, System.Drawing.Image>()
	{
		{ "0000", WindowsFormsApplication5.Properties.Resources.U0000 },
		{ "0001", WindowsFormsApplication5.Properties.Resources.U0001 },
		// etc
		{ "1100", WindowsFormsApplication5.Properties.Resources.U1101 },
	};
	
	private static Dictionary<string, PictureBox> _tiles = new Dictionary<string, PictureBox>()
	{
		{ "a1", a1 },
		{ "b1", b1 },
		// etc
		{ "h8", h8 },
	};
	
	private static Dictionary<string, Dictionary<string, System.Drawing.Image>> _shadings = new Dictionary<string, Dictionary<string, System.Drawing.Image>>()
	{
		{ "a1", _shaded },
		{ "b1", _unshaded },
		// etc
		{ "h8", _shaded },
	};
	
	private void DisplayBoardDisplayTile(string xtile, string piece)
	{
		_tiles[xtile].Image = _shadings[xtile][piece];
	}
