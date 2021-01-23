    [Fact]
    public void ShouldEmitErrorsToObservable()
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
        Func<CustomException, IObservable<int>> catcher = null;
        catcher = ex => source.Select(projection).Catch(catcher);
        var errorObservable = source
            .Select(projection)
            .Materialize()
            .Where(notification => notification.Kind == NotificationKind.OnError)
            .Select(notification => notification.Exception)
            .OfType<CustomException>()
            .Select(exception => new NewObject(exception.Message));
        var normalSubscription = source.Select(projection).Catch(catcher).Subscribe(values.Add);
        var errorSubscription = errorObservable.Subscribe(errors.Add);
        source.OnNext(0);
        source.OnNext(1);
        source.OnNext(2);
        Assert.Equal(2, values.Count);
        Assert.Equal(1, errors.Count);
    }
