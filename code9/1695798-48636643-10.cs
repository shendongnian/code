    public class QueryViewModel : DetailViewModelBase, ICommonViewModel
    {
      private AttributionInputWrapper _attributionInput;
      public AttributionInputWrapper AttributionInput
        {
            get => _attributionInput;
            set
            {
                _attributionInput = value;
                OnPropertyChanged();
            }
        }
     }
