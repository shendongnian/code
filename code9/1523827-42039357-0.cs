		readonly Stopwatch sw = new Stopwatch();
		public void Benchmark()
		{
			var t1 = Test(View);
			var t2 = Test(() => View("[ActionName]"));
			var t4 = Test(() => View(new Model()));
			var t3 = Test(() => View("[ActionName]", new Model()));
			string result = $"{t1} - {t2} - {t3} - {t4}";
            //Results:
            //4466 - 4856 - 6969 - 6977
            //4551 - 4986 - 7070 - 7056
            //5181 - 5263 - 7142 - 7864
		}
		public long Test(Func<ViewResult> f)
		{
			sw.Start();
			for (int i = 0; i < 100000000; i++)
			{ var x = f(); }
			sw.Stop();
			long t = sw.ElapsedMilliseconds;
			sw.Reset();
			return t;
		}
