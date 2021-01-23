public static IObservable<Unit> ToSignal<TDontCare>(this IObservable<TDontCare> source) 
    => source.Select(_ => Unit.Default);
\\ The subscription will be then
Texts.Events().MouseUp
     .ToSignal()
     .InvokeCommand(ViewModel, x => x.DoSomething);
