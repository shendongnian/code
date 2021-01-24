	public class TestProcess : ReactiveTest
	{
		[Test]
		public void ErrorFreeStreamProcessedCorrectly()
		{
			var expected = new List<string>
			{
				"Preprocess(1)", "1", "Postprocess(1)",
				"Preprocess(2)", "2", "Postprocess(2)"
			};
			
			var actual = new List<string>();
			
			var scheduler = new TestScheduler();
			
			var xs = scheduler.CreateColdObservable<int>(
				OnNext(100, 1),
				OnNext(200, 2),
				OnCompleted<int>(300)
			);
	
			var sut = xs.Process(
				x => actual.Add($"Preprocess({x})"),
				x => actual.Add($"Postprocess({x})"));
				
			var result = scheduler.CreateObserver<int>();				
			
			sut.Do(x => actual.Add(x.ToString())).Subscribe(result);
			
			scheduler.Start();
	
			result.Messages.AssertEqual(
				OnNext(100, 1),
				OnNext(200, 2),
				OnCompleted<int>(300)
			);
			
			actual.ShouldBe(expected);
		}
	
		[Test]
		public void ErrorInPreprocessHandledCorrectly()
		{
			var expected = new List<string>
			{
				"Preprocess(1)", "1", "Postprocess(1)",
				"Error"
			};
	
			var expectedException = new ApplicationException("Error");
	
			var actual = new List<string>();
	
			var scheduler = new TestScheduler();
	
			var xs = scheduler.CreateColdObservable<int>(
				OnNext(100, 1),
				OnNext(200, 2),
				OnCompleted<int>(300)
			);
	
			var sut = xs.Process(
				x => actual.Add(x == 1 ? $"Preprocess({x})" : throw expectedException),
				x => actual.Add($"Postprocess({x})"));
	
			var result = scheduler.CreateObserver<int>();
	
			sut.Do(x => actual.Add(x.ToString()),
				   e => actual.Add(e.Message)).Subscribe(result);
	
			scheduler.Start();
	
			result.Messages.AssertEqual(
				OnNext(100, 1),
				OnError<int>(200, expectedException)
			);
	
			actual.ShouldBe(expected);
		}
	
		[Test]
		public void ErrorInPostprocessHandledCorrectly()
		{
			var expected = new List<string>
			{
				"Preprocess(1)", "1", "Postprocess(1)",
				"Preprocess(2)", "2", "Error"
			};
	
			var expectedException = new ApplicationException("Error");
	
			var actual = new List<string>();
	
			var scheduler = new TestScheduler();
	
			var xs = scheduler.CreateColdObservable<int>(
				OnNext(100, 1),
				OnNext(200, 2),
				OnCompleted<int>(300)
			);
	
			var sut = xs.Process(
				x => actual.Add($"Preprocess({x})"),
				x => actual.Add(x == 1 ? $"Postprocess({x})" : throw expectedException));
	
			var result = scheduler.CreateObserver<int>();
	
			sut.Do(x => actual.Add(x.ToString()),
				   e => actual.Add(e.Message)).Subscribe(result);
	
			scheduler.Start();
	
			result.Messages.AssertEqual(
				OnNext(100, 1),
				OnNext(200, 2),
				OnError<int>(200, expectedException)
			);
	
			actual.ShouldBe(expected);
		}
	
		[Test]
		public void ErrorInSubscriberHandledCorrectly()
		{
			var expected = new List<string>
			{
				"Preprocess(1)", "1", "Postprocess(1)",
				"Preprocess(2)"
			};
	
			var expectedException = new ApplicationException("Error");
	
			var actual = new List<string>();
	
			var scheduler = new TestScheduler();
	
			var xs = scheduler.CreateColdObservable<int>(
				OnNext(100, 1),
				OnNext(200, 2),
				OnCompleted<int>(300)
			);
	
			var sut = xs.Process(
				x => actual.Add($"Preprocess({x})"),
				x => actual.Add($"Postprocess({x})"));
	
			var result = scheduler.CreateObserver<int>();
	
			sut.Subscribe(
			    x => { if (x != 1) throw expectedException; else actual.Add(x.ToString()); result.OnNext(x); },
				result.OnError,
				result.OnCompleted);
			
			try
			{	        
				scheduler.Start();
			}
			catch
			{
			
			}		
	
			result.Messages.AssertEqual(
				OnNext(100, 1)
			);
	
			actual.ShouldBe(expected);
		}
	}
