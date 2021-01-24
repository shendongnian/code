    private void OnSorting(object sender, DataGridSortingEventArgs e) {
        if (e.Column.SortMemberPath == "Value") {
            // get view
            var source = (ListCollectionView) CollectionViewSource.GetDefaultView(this.Items);
            // manually change sort direction to the next value
            // so null > ascending > descending > back to null
            var sort = e.Column.SortDirection;
            if (sort == null)
                sort = ListSortDirection.Ascending;
            else if (sort == ListSortDirection.Ascending)
                sort = ListSortDirection.Descending;
            else
                sort = null;
            if (sort != null) {
                // first figure out correct group ordering
                var sortedGroups = dataGrid.ItemsSource.OfType<Item>()
                    .GroupBy(c => c.GroupName)
                    .Select(c => new {GroupName = c.Key, MinValue = c.Min(r => r.Value)})
                    .OrderBy(c => c.MinValue)
                    .Select(c => c.GroupName)
                    .ToArray();
                // now set collection view custom sort to out comparer
                source.CustomSort = new ItemComparer(sortedGroups, sort == ListSortDirection.Ascending);
            }
            else {
                // otherwise remove custom sort and sort as usual
                source.CustomSort = null;
            }
            e.Column.SortDirection = sort;
            e.Handled = true;
        }
    }
    public class ItemComparer : IComparer {
        private readonly string[] _sortedGroups;
        private readonly bool _asc;
        public ItemComparer(string[] sortedGroups, bool asc) {
            _sortedGroups = sortedGroups;
            _asc = asc;
        }
        public int Compare(object ox, object oy) {
            var x = (Item) ox;
            var y = (Item) oy;
            if (x.GroupName == y.GroupName) {
                // if group names are the same - sort as usual, by Value
                return x.Value.CompareTo(y.Value) * (_asc ? 1 : -1);
            }
            // otherwise - sort by group name using the order we already figured out at previous step
            return (Array.IndexOf(_sortedGroups, x.GroupName) - Array.IndexOf(_sortedGroups, y.GroupName)) * (_asc ? 1 : -1);
        }
    }
