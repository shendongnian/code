    var Polygons = new ObservableCollection<Polygon>(myList);
    Polygons.Subscriber<NotifyCollectionChangedEventArgs>
        ("CollectionChanged",
        () => MessageBox.Show("hello"), //must in a public class and a public static method
        e => e.OldItems != null);
