    public class MyViewModel : ViewModelBase
    {
        #region Whenever Property
        private DateTime? _whenever = default(DateTime?);
        public DateTime? Whenever
        {
            get { return _whenever; }
            set { SetProperty(ref _whenever, value); }
        }
        #endregion Whenever Property
    }
