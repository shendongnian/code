    private static void Main(string[] args) {
			List<Performance> performances = new List<Performance>();
			Performance perf1 = new Performance {
				EndTime = 10,
				Stage = 5
			};
			Performance perf2 = new Performance
			{
				EndTime = 5,
				Stage = 2
			};
			performances.Add(perf2);
			performances.Add(perf1);
			
			var test = performances.Any(perf => perf.Stage > 3 && perf.EndTime > 3);
			var stop = "i";
		}
	}
	internal class Performance {
		private int _endTime;
		private int _stage;
		public int Stage
		{	
			get { return _stage; }
			set { _stage = value; }
		}
		public int EndTime
		{
			get { return _endTime; }
			set { _endTime = value; }
		}
	}
