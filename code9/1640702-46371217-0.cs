    using System.Reactive.Linq;
    ...
 
    System.Reactive.Linq.Observable
        .FromEventPattern<RoutedEventArgs>(btn, "Click")
        .Sample(TimeSpan.FromSeconds(10)) //take the last event for every 10 seconds
        .Subscribe(_ => { MessageBox.Show("clicked!"); });
