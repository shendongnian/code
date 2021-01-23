	public static class BehaviorsEx
	{
		private class Subject<TSubject> : IInvoker<TSubject, TSubject>
		{
			private TSubject _subject;
	
			public Subject(TSubject subject)
			{
				_subject = subject;
			}
	
			public TSubject Invoke() { return _subject; }
		}
	
		private class Invoker<TSubject, TResult> : IInvoker<TSubject, TResult>
		{
			private IInvoker<TSubject> _inner;
			private Func<TSubject, TResult> _behaviour;
	
			public Invoker(IInvoker<TSubject> inner, Func<TSubject, TResult> behaviour)
			{
				_inner = inner;
				_behaviour = behaviour;
			}
	
			public TResult Invoke()
			{
				var x = _inner.Invoke();
				return _behaviour(x);
			}
		}
	
		public static IInvoker<TSubject> CreateBehaviour<TSubject>(this TSubject @this)
		{
			return new Subject<TSubject>(@this);
		}
	
		public static IInvoker<TResult> AddBehaviour<TSubject, TResult>(this IInvoker<TSubject> @this, Func<TSubject, TResult> behaviour)
		{
			return new Invoker<TSubject, TResult>(@this, behaviour);
		}
	}
	
	public interface IInvoker<TResult>
	{
		TResult Invoke();
	}
	
	public interface IInvoker<TSubject, TResult> : IInvoker<TResult>
	{
	}
