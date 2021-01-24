    interface IInitializable {
        void Initialize(object obj);
    }
    ...
    protected abstract TResponse Handle<TResponse>(T command) where TResponse : new, IInitializable;
    ...
    protected override TResponse Handle<TResponse>(ListFilmsByIdCommand command) where TResponse : new, IInitializable {
        var res = new TResponse();
        res.Initialize(9);
        return res;
    }
