	public class Test : ReactiveTest {
		[Fact]
		public void Observe_distint_nonDistinc() {
			var scheduler = new TestScheduler();
			var source = scheduler.CreateHotObservable(
				OnNext(100, "a"),
				OnNext(110, "b"),
				OnNext(200, "a"),
				OnNext(220, "c"),
				OnNext(221, "a")
			).Publish();
			var distinnctResults = scheduler.CreateObserver<string>();
			source.Distinct().Subscribe(distinnctResults);
			var duplicatesResults = scheduler.CreateObserver<string>();
			source.CollectDuplicates().Subscribe(duplicatesResults);
			source.Connect();
			scheduler.AdvanceBy(1000);
			distinnctResults.Messages.AssertEqual(OnNext(100, "a"), OnNext(110, "b"), OnNext(220, "c"));
			duplicatesResults.Messages.AssertEqual(OnNext(200,"a"),OnNext(221,"a"));
		}
	}
	public static class RxEx{
		class DubplicateCollector<T> : IEqualityComparer<T> {
			readonly Subject<T> _matches = new Subject<T>();
			public IObservable<T> Matches => _matches;
			public bool Equals(T x, T y) {
				var @equals = x.Equals(y);
				if (equals)
					_matches.OnNext(x);
				return @equals;
			}
			public int GetHashCode(T obj) {
				return obj.GetHashCode();
			}
		}
		public static IObservable<TSource> CollectDuplicates<TSource>(this IObservable<TSource> source) {
			var dubplicateCollector = new DubplicateCollector<TSource>();
			var compositeDisposable = new CompositeDisposable { source.Distinct(dubplicateCollector).Subscribe() };
			return Observable.Create<TSource>(observer => {
				var disposable = dubplicateCollector.Matches.Subscribe(observer.OnNext, observer.OnError, observer.OnCompleted);
				compositeDisposable.Add(disposable);
				return () => compositeDisposable.Dispose();
			});
		}
	}  
