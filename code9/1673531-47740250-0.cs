	foreach (var cell in board.Cells)
	{
		int x = cell.Column;
		int y = cell.Row;
		Console.SetCursorPosition(x * 2, y * 2);
		Console.Write(cell.Value.HasValue ? cell.Value.Value.ToString() : "  ");
	}
	Console.ReadKey();
