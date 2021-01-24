	class PointList : List<Point>
	{
		/// <summary>
		/// Adds the point to the list and checks for perimeters
		/// </summary>
		/// <param name="point"></param>
		/// <returns>Returns true if it created at least one structure</returns>
		public bool AddAndVerify(Point point)
		{
			this.Add(point);
			bool result = LookForPerimeter(point, point, point);
			Console.WriteLine(result);
			return result;
		}
		private bool LookForPerimeter(Point point, Point last, Point original)
		{
			foreach (Point linked in this.Where(p => 
				(p.X == point.X -1 && p.Y == point.Y)
				|| (p.X == point.X + 1 && p.Y == point.Y)
				|| (p.X == point.X && p.Y == point.Y - 1)
				|| (p.X == point.X && p.Y == point.Y + 1)
			))
			{
				if (!linked.Equals(last))
				{
					if (linked == original) return true;
					bool subResult = LookForPerimeter(linked, point, original);
					if (subResult) return true;
				}
			}
			return false;
		}
	}
