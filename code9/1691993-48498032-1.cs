	class MyClass : ReactiveTest {
		[Fact]
		public void MethodName4() {
			var strings = new Subject<string>();
			var testScheduler = new TestScheduler();
			testScheduler.Schedule("", TimeSpan.FromTicks(10), (scheduler, s) => {
				strings.OnNext("a");
				strings.OnNext("b");
			});
			testScheduler.Schedule("", TimeSpan.FromTicks(20), (scheduler, s) => {
				strings.OnNext("c");
			});
			var numbers = testScheduler.CreateHotObservable(OnNext(10, 1), OnNext(20, 2), OnNext(30, 3), OnNext(40, 4), OnNext(50, 5));
			numbers.Zip(strings.RepeatAllDuringSilence(TimeSpan.FromTicks(10),testScheduler), (i, s) => (i, s)).Subscribe(tuple => WriteLine(tuple));
			testScheduler.AdvanceBy(50);
		}
	}
