    private static void Main(string[] args) {
			Test1();
		}
		#region Test1
		private static void Test1() {
			var performances = new List<Performance>();
			var thestm = new List<Performance>();
			var perf1 = new Performance {
				StartTime = 2,
				EndTime = 10,
				Stage = 4
			};
			var perf2 = new Performance {
				StartTime = 1,
				EndTime = 5,
				Stage = 4
			};
			var perf3 = new Performance {
				StartTime = 4,
				EndTime = 6,
				Stage = 4
			};
			var perf4 = new Performance {
				StartTime = 1,
				EndTime = 9,
				Stage = 4
			};
			performances.Add(perf2);
			performances.Add(perf1);
			thestm.Add(perf3);
			thestm.Add(perf4);
			var timeIsAvailable = false;
			foreach (var pp in thestm) {
				timeIsAvailable = performances.Any(perf => perf.EndTime > pp.EndTime && perf.StartTime < pp.StartTime &&
															perf.Stage == pp.Stage);
				if (timeIsAvailable) {
					break;
				}
			}
			var stop = "i";
		}
	}
	internal class Performance {
		public int Stage { get; set; }
		public int StartTime { get; set; }
		public int EndTime { get; set; }
	}
