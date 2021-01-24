    > #r "WindowsBase"
    > #r "PresentationCore"
    > #r "PresentationFramework"
    > using System.Windows;
    > using System.Linq;
    > using System.Runtime.CompilerServices;
    > var types = from t in typeof(FrameworkElement).Assembly.GetTypes()
    .             where typeof(FrameworkElement).IsAssignableFrom(t)
    .             select t;
    > foreach (var t in types) RuntimeHelpers.RunClassConstructor(t.TypeHandle);
    > var events = from e in EventManager.GetRoutedEvents()
    .              where e.RoutingStrategy == RoutingStrategy.Direct
    .              select $"{e.OwnerType.Name}.{e.Name}";
    > foreach (var e in events) Console.WriteLine(e);
