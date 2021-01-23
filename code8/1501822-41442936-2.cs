    internal class Fallible
    {
        public static Fallible<TResult> Try<TResult, TException>(Func<TResult> action) where TException : Exception
        {
            try
            {
                return Success(action());
            }
            catch (TException exception)
            {
                return Error<TResult>(exception);
            }
        }
        public static Fallible<T> Success<T>(T value)
        {
            return new Fallible<T>(value);
        }
        public static Fallible<T> Error<T>(Exception exception)
        {
            return new Fallible<T>(exception);
        }
    }
    internal class Fallible<T>
    {
        public Fallible(T value)
        {
            Value = value;
            IsSuccess = true;
        }
        public Fallible(Exception exception)
        {
            Exception = exception;
            IsError = true;
        }
        public T Value { get; private set; }
        public Exception Exception { get; private set; }
        public bool IsSuccess { get; private set; }
        public bool IsError { get; private set; }
    }
    [Fact]
    public void ShouldMapErrorsToFallible()
    {
        Subject<int> source = new Subject<int>();
        List<int> values = new List<int>();
        List<NewObject> errors = new List<NewObject>();
        Func<int, int> projection =
            value =>
            {
                if (value % 2 == 1) throw new CustomException("Item is odd");
                return value;
            };
        var observable = source
            .Select(value => Fallible.Try<int, CustomException>(() => projection(value)))
            .Publish()
            .RefCount();
        var errorSubscription = observable
            .Where(fallible => fallible.IsError)
            .Select(fallible => new NewObject(fallible.Exception.Message))
            .Subscribe(errors.Add);
        var normalSubscription = observable
            .Where(fallible => fallible.IsSuccess)
            .Select(fallible => fallible.Value)
            .Subscribe(values.Add);
        source.OnNext(0);
        source.OnNext(1);
        source.OnNext(2);
        Assert.Equal(2, values.Count);
        Assert.Equal(1, errors.Count);
    }
