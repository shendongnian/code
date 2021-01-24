	public class DistancesViewModel 
    {
		public ICollection<Distance> Distances { get; set; }
		
		public int TotalDistanceRun {  
			get {
				return Distances.Sum(d => d.DistanceRun)
			}
		}
	}
