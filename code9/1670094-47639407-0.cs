    using System;
	using System.Collections.Generic;
	using System.Linq;
						
	public class Program
	{
		public static void Main()
		{
			Random rand = new Random();	
			int num;
			num = Convert.ToInt32(Console.ReadLine());
			Func<int> valueGenerator = () => { return rand.Next(0,2); };
			var dungeon = new Grid<int>(num, num, valueGenerator);
	
			foreach(var row in dungeon.Rows)
			{
				// First() - https://msdn.microsoft.com/en-us/library/bb291976(v=vs.110).aspx
				if (row.First().Row == 0)
				{
					Console.WriteLine("#-#-#-#-#");
				}
				// ToArray() - https://msdn.microsoft.com/en-us/library/bb298736(v=vs.110).aspx
				var rowValues = row.Select(r => r.Value.ToString()).ToArray();
				
				// string.Join() - https://msdn.microsoft.com/en-us/library/57a79xd0(v=vs.110).aspx
				var rowDisplay = string.Join("|", rowValues);
				
				// $ ie Interpolated Strings - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interpolated-strings
				Console.WriteLine($"|{rowDisplay}|");
				Console.WriteLine("#-#-#-#-#");	
			}
		}
		
		public class Grid<T>
		{
			private int _numberOfRows;
			private int _numberOfColumns;
			
			// List<> - https://msdn.microsoft.com/en-us/library/6sh2ey19(v=vs.110).aspx
			private List<Cell<T>> _cells;
			
			public Grid(int numberOfRows, int numberOfColumns)
			{
				if (numberOfRows == 0)
					throw new ArgumentOutOfRangeException("numberOfRows must be greater than zero.");
				if (numberOfColumns == 0)
					throw new ArgumentOutOfRangeException("numberOfColumns must be greater than zero.");
				
				_numberOfRows = numberOfRows;
				_numberOfColumns = numberOfColumns;
				
				// Enumerable.Range - https://msdn.microsoft.com/en-us/library/system.linq.enumerable.range(v=vs.110).aspx
				_cells = Enumerable.Range(0, _numberOfRows)
					// Select - https://msdn.microsoft.com/en-us/library/bb548891(v=vs.110).aspx
					.Select(r => Enumerable.Range(0, _numberOfColumns)
							.Select(c => new Cell<T>
									{
										Row = r,
										Col = c
									})
							// ToList() - https://msdn.microsoft.com/en-us/library/bb342261(v=vs.110).aspx
							.ToList())
					// - https://msdn.microsoft.com/en-us/library/system.linq.enumerable.selectmany(v=vs.110).aspx
					.SelectMany(c => c)
					.ToList();
			}
			
			public Grid(int numberOfRows, int numberOfColumns, Func<T> valueGenerator)
			{
				if (numberOfRows == 0)
					throw new ArgumentOutOfRangeException("numberOfRows must be greater than zero.");
				if (numberOfColumns == 0)
					throw new ArgumentOutOfRangeException("numberOfColumns must be greater than zero.");
				
				_numberOfRows = numberOfRows;
				_numberOfColumns = numberOfColumns;
				
				_cells = Enumerable.Range(0, _numberOfRows)
					.Select(r => Enumerable.Range(0, _numberOfColumns)
							.Select(c => new Cell<T>
									{
										Row = r,
										Col = c,
										Value = valueGenerator()
									})
							.ToList())
					.SelectMany(c => c)
					.ToList();
			}
			
			public IEnumerable<ICell<T>> Cells
			{
				get
				{
					return _cells;
				}
			}
			
			public IEnumerable<IEnumerable<ICell<T>>> Rows
			{
				get
				{			
					return _cells.GroupBy(c => c.Row)
						.Select(gs => gs.OrderBy(g => g.Col).ToList())
						.ToList();
				}
			}
	
			public IEnumerable<IEnumerable<ICell<T>>> Columns
			{
				get
				{
					return _cells.GroupBy(c => c.Col)
						.Select(gs => gs.OrderBy(g => g.Row).ToList())
						.ToList();
				}
			}
			
			// We expose the Interface because we don't want anyone outside grid modifying
			// Row or Col
			public interface ICell<T>
			{
				int Row { get; }
				int Col { get; }
				T Value { get; set; }
			}
									
			private class Cell<T> : ICell<T>
			{
				public T Value { get; set; }
				public int Row { get; set; }
				public int Col { get; set; }
			}
	
					
		}
		
	}
