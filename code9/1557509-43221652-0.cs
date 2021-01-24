    public class CatalogViewModel : BindableBase
    {
        private string selectedValue;
        public string SelectedValue
        {
            get { return selectedValue; }
            set { SetProperty<string>(ref selectedValue, value); }
        }
    ...
    }
