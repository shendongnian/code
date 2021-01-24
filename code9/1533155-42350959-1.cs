	public class MetricComparator : IEqualityComparer<Metric>
	{
		/// <summary>
		/// Returns true if two given Metric objects should be considered equal
		/// </summary>
		public bool Equals(Metric x, Metric y)
		{
			return
				x.Source == y.Source &&
				x.Type == y.Type &&
				x.Title == y.Title &&
				x.Public == y.Public &&
				
				x.DayAvg == y.DayAvg &&
				x.DayMax == y.DayMax &&
				x.DayMin == y.DayMin &&
				
				x.HourAvg == y.HourAvg &&
				x.HourMax == y.HourMax &&
				x.HourMin == y.HourMin &&
				x.CurrentValue == y.CurrentValue;
		}
		/// <summary>
		/// Returns a hash of the given Metric object
		/// </summary>
		public int GetHashCode(Metric metric)
		{
			return 
				2 * metric.Source.GetHashCode() +
				3 * metric.Type.GetHashCode() +
				5 * metric.Title.GetHashCode() +
				7 * metric.Public.GetHashCode() +
				
				11 * metric.DayAvg.GetHashCode() +
				13 * metric.DayMax.GetHashCode() +
				17 * metric.DayMin.GetHashCode() +
				23 * metric.HourAvg.GetHashCode() +
				29 * metric.HourMax.GetHashCode() +
				31 * metric.HourMin.GetHashCode() +
				37 * metric.CurrentValue.GetHashCode();
		}
	}
