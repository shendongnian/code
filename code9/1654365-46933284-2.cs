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
            if (x == null && y == null)
                return 0;
            else if (x == null)
                return -1;
            else if (y == null)
                return 1;
            else
            {
                PropertyInfo pi = typeof(T).GetProperty(_propertyName);
                if (pi == null)
                    return 0;
                object a = pi.GetValue(x);
                object b = pi.GetValue(y);
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
