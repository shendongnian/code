    public class WVWellModel : Notifier
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return this._isSelected;
            }
            set
            {
                this._isSelected = value; OnPropertyChanged();
            }
        }
