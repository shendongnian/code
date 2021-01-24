    public class DataCaptureViewModel : BaseViewModel
    {
    ...
         public ObservableCollection<Item> SelectedItems { get; set; }
         public override void SetNavigationContext(object context)
         {
              var selectedItems = context as ObservableCollection<Item>;
              SelectedItems = selectedItems;
         }
    }
