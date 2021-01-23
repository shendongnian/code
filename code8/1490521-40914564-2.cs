    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    namespace MvvmLight1.ViewModel
    {
        /// <summary>
        /// This class contains properties that the main View can data bind to.
        /// <para>
        /// See http://www.mvvmlight.net
        /// </para>
        /// </summary>
        public class MainViewModel : ViewModelBase
        {
            private bool isEnabled;
            public bool IsEnabled
            {
                get { return isEnabled; }
                set
                {
                    // 'Set' the update first before updating the value 
                    // of the backing field so that the old value 'false'
                    // can be sent out with the update with the new value 'true'
                    Set(ref isEnabled, value);
                    isEnabled = value;
                }
            }
            public RelayCommand EnableCommand { get; set; }
            /// <summary>
            /// Initializes a new instance of the MainViewModel class.
            /// </summary>
            public MainViewModel()
            {
                EnableCommand = new RelayCommand(EnableButton);
            }
            private void EnableButton()
            {
                IsEnabled = !IsEnabled;
            }
        }
    }`
