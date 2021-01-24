    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        CollectionViewSource source = (CollectionViewSource)(this.Resources["MyCollectionViewSource1"]);
        ListCollectionView view = (ListCollectionView)source.View;
        view.CustomSort = new CustomSorter();
    }
    public class CustomSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            var itemx = x as PermissionItemViewModel;
            var itemy = y as PermissionItemViewModel;
            return $"{itemx.Permission}".CompareTo($"{itemy.Permission}");
        }
    }
