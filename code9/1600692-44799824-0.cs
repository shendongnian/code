    /// Use https://louthy.github.io/language-ext/LanguageExt.Core/LanguageExt/Option_A.htm
    /// instead of null ( works with value types and reference types )
    using LanguageExt.Prelude;
    /// Wraps the type in Optional of T and starts the sequence with None
    public static IObservable<Option<T>> StartWithNone<T>(this IObservable<T> so) => so.Select( Some ).StartWith( None );
    /// Create a ReactiveCommand that samples a source observable. The
    /// source is immediately subscribed to so that when the command
    /// is executed the previous value is available to the execution
    /// function.
    public static ReactiveCommand<Unit,Unit> ReactiveCommandCreate<T>
        (this IObservable<T> source
         , Action<T> execute
         , IObservable<bool> canExecute)
    {
        var so = source.Replay(1).RefCount();
        return ReactiveCommand.CreateFromTask
            ( async () => execute(await so.FirstAsync())
              , canExecute.CombineLatest( so.StartWithNone(), (ce, o)=>ce && o.IsSome ));
    }
    
