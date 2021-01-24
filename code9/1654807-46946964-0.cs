	private static Dictionary<string, System.Drawing.Image> _whitePieces = new Dictionary<string, System.Drawing.Image>()
	{
		{ "0000", WindowsFormsApplication5.Properties.Resources.S0000 },
		{ "0001", WindowsFormsApplication5.Properties.Resources.S0001 },
		//etc
		{ "1100", WindowsFormsApplication5.Properties.Resources.S1101 },
	};
	
	private static Dictionary<string, System.Drawing.Image> _blackPieces = new Dictionary<string, System.Drawing.Image>()
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
	
	private static Dictionary<string, Dictionary<string, System.Drawing.Image>> _pieces = new Dictionary<string, Dictionary<string, System.Drawing.Image>>()
	{
		{ "a1", _whitePieces },
		{ "b1", _blackPieces },
		// etc
		{ "h8", _whitePieces },
	};
	
	private void DisplayBoardDisplayTile(string xtile, string piece)
	{
		_tiles[xtile].Image = _pieces[xtile][piece];
	}
