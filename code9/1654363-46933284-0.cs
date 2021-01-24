    public class StringComparer<T> : IComparer where T : class
    {
        private static readonly CultureInfo culture = new CultureInfo("sv-SE");
        private string _propertyName;
        private int _direction;
        public StringComparer(string propertyName, ListSortDirection direction)
        {
            _propertyName = propertyName;
            _direction = direction == ListSortDirection.Descending ? 1 : -1;
        }
        public int Compare(object x, object y)
        {
            T obj1 = x as T;
            T obj2 = y as T;
            if (obj1 == null && obj2 == null)
                return 0;
            else if (obj1 == null)
                return -1;
            else if (obj2 == null)
                return 1;
            else
            {
                PropertyInfo pi = typeof(T).GetProperty(_propertyName);
                if (pi == null)
                    return 0;
                object a = pi.GetValue(obj1);
                object b = pi.GetValue(obj2);
                if (a == null && b == null)
                    return 0;
                else if (a == null)
                    return -1;
                else if (b == null)
                    return 1;
                return string.Compare(a.ToString(), b.ToString(), false, culture) * _direction;
            }
        }
    }
----------
    private void SortByColumns(object sender, RoutedEventArgs e)
    {
        GridViewColumnHeader column = (sender as GridViewColumnHeader);
        string sortBy = column.Tag.ToString();
        if (listViewSortCol != null)
        {
            AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
            siteListView.Items.SortDescriptions.Clear();
        }
        ListSortDirection newDir = ListSortDirection.Ascending;
        if (listViewSortCol == column /*&& listViewSortAdorner.Direction == newDir*/)
            newDir = ListSortDirection.Descending;
        listViewSortCol = column;
        listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
        AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
        ListCollectionView lvi = CollectionViewSource.GetDefaultView(siteListView.ItemsSource) as ListCollectionView;
        if (lvi != null)
        {
            lvi.CustomSort = new StringComparer<MyTuple>(sortBy, newDir);
        }
        else
            siteListView.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
    }
