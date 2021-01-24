	public class BallPlayer
	{
		public string Name { get; set; }
		public int NumberOfHits { get; set; }
		public bool IsMvp { get; set; }
		public bool IsAllStar { get; set; }
		public double SalaryPerHit
		{
			get
			{
				var salary = 10.0;
				if( NumberOfHits < 150 )
					salary = 15;
				else if( NumberOfHits < 200 )
					salary = 20;
				else if( NumberofHits < 250 )
					salary = 25;
				return salary;
			}
		}
		public double BonusMultiplier
		{
			get
			{
				var multiplier = 1.0;
				if( IsMvp ) multiplier = 1.1;
				else if( IsAllStar ) multiplier = 1.2;
				return multiplier;
			}
		}
		public double CalculateSalary() =>
			SalaryPerHit * BonusMultiplier * NumberOfHits;
	}
