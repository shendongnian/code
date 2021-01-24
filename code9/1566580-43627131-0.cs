    public class DataGridAsyncViewModel : Notifier
    {
      public VirtualCollection ItemsProvider { get; }
      private VirtualCollectionItem _selectedGridItem;
      public VirtualCollectionItem SelectedGridItem
      {
        get { return _selectedGridItem; }
        set { Set(ref _selectedGridItem, value); }
      }
      public object SelectedItem => SelectedGridItem?.IsLoading == false ? SelectedGridItem?.Item : null;
      public DataGridAsyncViewModel([NotNull] VirtualCollection itemsProvider)
      {
        if (itemsProvider == null) throw new ArgumentNullException(nameof(itemsProvider));
        ItemsProvider = itemsProvider;
      }
    }
