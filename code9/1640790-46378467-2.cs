	public class Board
	{
		// Enumeration representing the outcome of a move on the board
		public enum MoveResult { Good, OutOfBounds, MineHit, Exit }
		
		// State of individual points on the board
		enum State { Empty, Mine, Exit }
		public Point CurrentPosition { get; private set; }
		public int Height { get; }
		public int Width { get; }
		State[,] board;
		public Board(int width, int height, Point initialPosition, Point exitPosition)
		{
			Width = width;
			Height = height;
			// Usually multidimensional arrays are represented in a way 
			// contrary to a normal (X,Y) coordinate system,
			// usually someArray[row(Y coordinate), column(X coordinate)], not the other way around.
			// This also makes printing the array simpler if you need it.
			board = new State[Height, Width];
			CurrentPosition = initialPosition;
			board[exitPosition.Y, exitPosition.X] = State.Exit;
		}
		public Board(int width, int height, Point initialPosition, Point exitPosition, IEnumerable<Point> minePositions)
			: this(width, height, initialPosition, exitPosition)
		{
			foreach(var pos in minePositions)
			{
				board[pos.Y, pos.X] = State.Mine;
			}
		}
		
		// Make a move on the board and return a value indicating if the move was successful
		public MoveResult Move(Direction direction)
		{
			// Get the move from the dictionary
			Point newPosition = CurrentPosition + moves[direction];
			
			if(newPosition.X < 0 || newPosition.Y < 0 || newPosition.X >= Width || newPosition.Y >= Height)
			{
				return MoveResult.OutOfBounds;
			}
			if(board[newPosition.Y, newPosition.X] == State.Mine)
			{
				return MoveResult.MineHit;
			}
			if(board[newPosition.Y, newPosition.X] == State.Exit)
			{
				return MoveResult.Exit;
			}
			CurrentPosition = newPosition;
			return MoveResult.Good;
		}
		static readonly Dictionary<Direction, Point> moves = new Dictionary<Direction, Point>
		{
			{ Direction.North, new Point(0, -1) },
			{ Direction.East,  new Point(1,  0) },
			{ Direction.South, new Point(0,  1) },
			{ Direction.West,  new Point(-1, 0) },
		};
	}
	
