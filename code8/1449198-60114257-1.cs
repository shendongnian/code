	public class BlockingCollectionMethodExtensionsTest : UnitTestBase
	{
		[Fact]
		public void FetchAtLeastOneBlocking_FirstEmpty_ThenSingleEntryAdded_ExpectBlocking_Test()
		{
			var queue = new BlockingCollection<int>();
			var startEvent = new ManualResetEvent(initialState: false);
			var completedEvent = new ManualResetEvent(initialState: false);
			List<int> fetchResult = null;
			var thread = new Thread(() =>
			{
				startEvent.Set();
				fetchResult = queue.FetchAtLeastOneBlocking<int>(maxCount: 3, log: null);
				completedEvent.Set();
			});
			thread.Start();
			var startedSuccess = startEvent.WaitOne(TimeSpan.FromSeconds(2)); // Wait until started
			Assert.True(startedSuccess);
			// Now wait for 2 seconds to ensure that nothing will be fetched
			Thread.Sleep(TimeSpan.FromSeconds(1));
			Assert.Null(fetchResult);
			// Add a new element and verify that the fetch method succeeded
			queue.Add(78);
			var completedSuccess = completedEvent.WaitOne(timeout: TimeSpan.FromSeconds(2));
			Assert.True(completedSuccess);
			Assert.NotNull(fetchResult);
			Assert.Single(fetchResult);
			Assert.Equal(78, fetchResult.Single());
		}
		[Fact]
		public void FetchAtLeastOneBlocking_FirstEmpty_ThenCompleted_ExpectOperationException_Test()
		{
			var queue = new BlockingCollection<int>();
			Exception catchedException = null;
			var startEvent = new ManualResetEvent(initialState: false);
			var exceptionEvent = new ManualResetEvent(initialState: false);
			List<int> fetchResult = null;
			var thread = new Thread(() =>
			{
				startEvent.Set();
                try
                {
					fetchResult = queue.FetchAtLeastOneBlocking<int>(maxCount: 3, log: null);
				}
                catch (Exception ex)
                {
					catchedException = ex;
					exceptionEvent.Set();
				}
			});
			thread.Start();
			var startedSuccess = startEvent.WaitOne(TimeSpan.FromSeconds(2)); // Wait until started
			Assert.True(startedSuccess);
			// Now wait for 2 seconds to ensure that nothing will be fetched
			Thread.Sleep(TimeSpan.FromSeconds(1));
			Assert.Null(fetchResult);
			// Now complete the queue and assert that fetching threw the expected exception
			queue.CompleteAdding();
			// Wait for the exception to be thrown
			var exceptionSuccess = exceptionEvent.WaitOne(TimeSpan.FromSeconds(2));
			Assert.True(exceptionSuccess);
			Assert.NotNull(catchedException);
			Assert.IsType<InvalidOperationException>(catchedException);
		}
		[Fact]
		public void FetchAtLeastOneBlocking_SingleEntryExists_ExpectNonblocking_Test()
		{
			var queue = new BlockingCollection<int>();
			// Add a new element and verify that the fetch method succeeded
			queue.Add(78);
			
			var startEvent = new ManualResetEvent(initialState: false);
			var completedEvent = new ManualResetEvent(initialState: false);
			List<int> fetchResult = null;
			var thread = new Thread(() =>
			{
				startEvent.Set();
				fetchResult = queue.FetchAtLeastOneBlocking<int>(maxCount: 3, log: null);
				completedEvent.Set();
			});
			thread.Start();
			var startedSuccess = startEvent.WaitOne(TimeSpan.FromSeconds(2)); // Wait until started
			Assert.True(startedSuccess);
			// Now wait for expected immediate completion
			var completedSuccess = completedEvent.WaitOne(timeout: TimeSpan.FromSeconds(2));
			Assert.True(completedSuccess);
			Assert.NotNull(fetchResult);
			Assert.Single(fetchResult);
			Assert.Equal(78, fetchResult.Single());
		}
		[Fact]
		public void FetchAtLeastOneBlocking_MultipleEntriesExist_ExpectNonblocking_Test()
		{
			var queue = new BlockingCollection<int>();
			// Add a new element and verify that the fetch method succeeded
			queue.Add(78);
			queue.Add(79);
			var startEvent = new ManualResetEvent(initialState: false);
			var completedEvent = new ManualResetEvent(initialState: false);
			List<int> fetchResult = null;
			var thread = new Thread(() =>
			{
				startEvent.Set();
				fetchResult = queue.FetchAtLeastOneBlocking<int>(maxCount: 3, log: null);
				completedEvent.Set();
			});
			thread.Start();
			var startedSuccess = startEvent.WaitOne(TimeSpan.FromSeconds(2)); // Wait until started
			Assert.True(startedSuccess);
			// Now wait for expected immediate completion
			var completedSuccess = completedEvent.WaitOne(timeout: TimeSpan.FromSeconds(2));
			Assert.True(completedSuccess);
			Assert.NotNull(fetchResult);
			Assert.Equal(2, fetchResult.Count);
			Assert.Equal(78, fetchResult[0]);
			Assert.Equal(79, fetchResult[1]);
		}
		[Fact]
		public void FetchAtLeastOneBlocking_MultipleEntriesExist_MaxCountExceeded_ExpectNonblocking_Test()
		{
			var queue = new BlockingCollection<int>();
			// Add a new element and verify that the fetch method succeeded
			queue.Add(78);
			queue.Add(79);
			queue.Add(80);
			queue.Add(81);
			var startEvent = new ManualResetEvent(initialState: false);
			var completedEvent = new ManualResetEvent(initialState: false);
			List<int> fetchResult = null;
			var thread = new Thread(() =>
			{
				startEvent.Set();
				fetchResult = queue.FetchAtLeastOneBlocking<int>(maxCount: 3, log: null);
				completedEvent.Set();
			});
			thread.Start();
			var startedSuccess = startEvent.WaitOne(TimeSpan.FromSeconds(2)); // Wait until started
			Assert.True(startedSuccess);
			// Now wait for expected immediate completion
			var completedSuccess = completedEvent.WaitOne(timeout: TimeSpan.FromSeconds(2));
			Assert.True(completedSuccess);
			Assert.NotNull(fetchResult);
			Assert.Equal(3, fetchResult.Count);
			Assert.Equal(78, fetchResult[0]);
			Assert.Equal(79, fetchResult[1]);
			Assert.Equal(80, fetchResult[2]);
		}
	}
