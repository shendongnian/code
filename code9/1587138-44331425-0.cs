     /// <summary>
    /// Common class for all tab viewmodels
    /// </summary>
    public abstract class TabViewModel : ViewModelBase
    {
        /// <summary>
        /// Tab name showed to the user
        /// </summary>
        private string tabName;
        /// <summary>
        /// Gets or sets the tab name
        /// </summary>
        public string TabName
        {
            get
            {
                return tabName;
            }
            set
            {
                tabName = value;
                OnPropertyChanged();
            }
        }
