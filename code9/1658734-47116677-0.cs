	private Random rand = new Random();
	
	private void playAgain_Click(object sender, EventArgs e)
	{
		TextBox[][] squares = new TextBox[][]
		{
			new TextBox[] { square1, square2, square3 },
			new TextBox[] { square4, square5, square6 },
			new TextBox[] { square7, square8, square9 },
		};
	
		const int rows = 3;
		const int columns = 3;
		char[,] board = new char[rows, columns];
	
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < columns; col++)
			{
				board[row, col] = rand.Next(2) == 0 ? 'O' : 'X';
				squares[row][col].Text = board[row, col].ToString();
			}
		}
	
		var scoring =
			Enumerable
				.Range(0, 3)
				.SelectMany(n => new[]
				{
					Enumerable.Range(0, 3).Select(x => board[n, x]),
					Enumerable.Range(0, 3).Select(x => board[x, n]),
				})
				.Concat(new[]
				{
					Enumerable.Range(0, 3).Select(x => board[x, x]),
					Enumerable.Range(0, 3).Select(x => board[x, 2 - x]),
				})
				.Select(xs => String.Join("", xs))
				.ToLookup(x => x);
	
		int xwins = scoring["XXX"].Count();
		int owins = scoring["OOO"].Count();
	
		if (xwins == 1 & owins == 0)
		{
			winnerBox.Text = "X wins!";
		}
		else if (xwins == 0 && owins == 1)
		{
			winnerBox.Text = "O wins!";
		}
		else if (xwins == 0 && owins == 0)
		{
			winnerBox.Text = "Draw";
		}
		else
		{
			winnerBox.Text = "Invalid Game";
		}
	}
