        public static void LoadUnloadHandler
           ( this FrameworkElement control
           , Func<IDisposable> action
           )
        {
            var state = false;
            var cleanup = new SerialDisposable();
            Observable.Merge
                (Observable.Return(control.IsLoaded)
                    , control.Events().Loaded.Select(x => true)
                    , control.Events().Unloaded.Select(x => false)
                )
                .Subscribe(isLoadEvent =>
                {
                    if (!state)
                    {
                        // unloaded state
                        if (isLoadEvent)
                        {
                            state = true;
                            cleanup.Disposable = new CompositeDisposable(action());
                        }
                    }
                    else
                    {
                        // loaded state
                        if (!isLoadEvent)
                        {
                            state = false;
                            cleanup.Disposable = Disposable.Empty;
                        }
                    }
                });
        }
        public static IObservable<T> LoadUnloadHandler<T>(this FrameworkElement control, Func<IObservable<T>> generator)
        {
            Subject<T> subject = new Subject<T>();
            control.LoadUnloadHandler(() => generator().Subscribe(v => subject.OnNext(v)));
            return subject;
        }
