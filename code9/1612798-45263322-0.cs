    public class FilterCommand : ICommand
    {
        public FilterCommand( FilterInfo filterInfo )
        {
            _filterInfo = filterInfo;
        }
        #region ICommand
        public bool CanExecute( object parameter )
        {
            return true;
        }
        public void Execute( object parameter )
        {
            ((Action<FilterInfo>)parameter)( _filterInfo );
        }
        public event EventHandler CanExecuteChanged;
        #endregion
        #region private
        private readonly FilterInfo _filterInfo;
        #endregion
    }
