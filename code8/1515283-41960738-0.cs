        public static IDisposable SubscribeDisposable<T>
            (this IObservable<T> observable, Func<T, IDisposable> action)
        {
            var d = new SerialDisposable();
            return observable
                .Finally(() => d.Dispose())
                .Subscribe(e =>
                {
                    d.Disposable = Disposable.Empty;
                    d.Disposable = action(e);
                });
        }
