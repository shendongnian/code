    public class ViewModel : INotifyPropertyChanged
        {
        private bool _someVariable;
        public bool SomeVariable
        {
            get { return _someVariable; }
            set
            {
                //// simplified code
                _someVariable = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SomeVariable)));
                SomeVariableChanged(this, EventArgs.Empty);
            }
        }
        public event EventHandler SomeVariableChanged = delegate { };
        /// <summary>
        /// Needed for updating the binding
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
