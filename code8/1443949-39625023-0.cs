        async Task<Unit> ActionAsync(int i)
        {
            if (i > 1)
                throw new Exception();
            i.Dump();
            return Unit.Default;
        }
        void Main()
        {
            var sb = new Subject<int>();
            sb.SelectMany(i => Observable.FromAsync(() => ActionAsync(i)).Materialize())
                .Subscribe(item =>
                {
                    if (item.Kind == NotificationKind.OnError)
                    {
                        item.Exception.Dump();
                    }
                    //else if (item.Kind == NotificationKind.OnNext)
                    //{
                    //    var value = item.Value;
                    //}
                    //else if (item.Kind == NotificationKind.OnCompleted)
                    //{
                    //}
                }
            );
            sb.OnNext(1);
            sb.OnNext(2);
            sb.OnNext(3);
        }
