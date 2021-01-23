    public class LogTestExecutionAttribute: BeforeAfterTestAttribute
	{
		public override void Before(MethodInfo methodUnderTest)
		{
			TestExecutionDataLogger.LogBegin(methodUnderTest);
		}
		public override void After(MethodInfo methodUnderTest)
		{
			TestExecutionDataLogger.LogEnd(methodUnderTest);
		}
	}
	public static class TestExecutionDataLogger
	{
		private static readonly string LogFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DbCoud", $"UnitTests_{DateTime.UtcNow:yyyy_MM_dd_HH_mm}_D_{AppDomain.CurrentDomain.Id}.csv");
		private static int _startedOrder = 0;
		private static int _endedOrder = 0;
		private static readonly ConcurrentDictionary<string, testExecutionData> testDataDict = new ConcurrentDictionary<string, testExecutionData>();
		private static readonly ConcurrentQueue<string> logQueue = new ConcurrentQueue<string>();
		public static void LogBegin(MethodInfo testInfo)
		{
			var name = $"{testInfo.DeclaringType.FullName}.{testInfo.Name}";
			var order = Interlocked.Add(ref _startedOrder, 1);
			var startedUtc = DateTime.UtcNow;
			var data = testDataDict.GetOrAdd(name, new testExecutionData());
			data.StartedUtc = startedUtc;
			data.StartedOrder = order;
			data.TestName = name;
			data.Status = "Started";
			data.StartThreadId = Thread.CurrentThread.ManagedThreadId;
			writeLog(data);
		}
		public static void LogEnd(MethodInfo testInfo)
		{
			var name = $"{testInfo.DeclaringType.FullName}.{testInfo.Name}";
			var dataEndedUtc = DateTime.UtcNow;
			var order = Interlocked.Add(ref _endedOrder, 1);
			var data = testDataDict[name];
			data.EndedUtc = dataEndedUtc;
			data.EndedOrder = order;
			data.Status = "Ended";
			data.EndThreadId = Thread.CurrentThread.ManagedThreadId;
			writeLog(data);
		}
		private static void writeLog(testExecutionData data)
		{
			logQueue.Enqueue(data.ToCsvLine());
			if (data.EndedOrder == 1)
			{
				Directory.CreateDirectory(Path.GetDirectoryName(LogFileName));
				Task.Run(logWriter);
			}
		}
		private static Task logWriter()
		{
			while (true)
			{
				var logs = new List<string>();
				string result;
				while (logQueue.TryDequeue(out result))
				{
					logs.Add(result);
				}
				if (logs.Any())
				{
					File.AppendAllLines(LogFileName, logs);
				}
			}
		}
		private class testExecutionData
		{
			public int StartedOrder { get; set; }
			public int EndedOrder { get; set; }
			public DateTime StartedUtc { get; set; }
			public DateTime EndedUtc { get; set; }
			public string TestName { get; set; }
			public string Status { get; set; }
			public int StartThreadId { get; set; }
			public int EndThreadId { get; set; }
			public string ToCsvLine() { return $"{TestName};{Status};{StartedOrder};{EndedOrder};{StartedUtc:o};{EndedUtc:o};{Math.Max(0, ( EndedUtc - StartedUtc ).TotalMilliseconds)};{StartThreadId};{EndThreadId}"; }
		}
	}
