    using System.Linq;
    ...
    private static void OnStructureChanged(
        DependencyObject depObj, DependencyPropertyChangedEventArgs eventArgs)
    {
        var tls = (IEnumerable<ITreeListStructure>)eventArgs.NewValue;
        var count = tls.Count();
    }
