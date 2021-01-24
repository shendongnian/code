    public class ViewModel
    {
        public ViewModel()
        {
            Func<bool> canExecute = () => !_isAExecuting && !_isBExecuting && !_isCExecuting;
            CommandA = new RelayCommand(ExecuteA, canExecute);
            CommandB = new RelayCommand(ExecuteB, canExecute);
            CommandC = new RelayCommand(ExecuteC, canExecute);
        }
        public RelayCommand CommandA { get; }
        public RelayCommand CommandB { get; }
        public RelayCommand CommandC { get; }
        private bool _isAExecuting;
        private void ExecuteA()
        {
            _isAExecuting = true;
            RefreshCommands();
            Task.Factory.StartNew(()=> System.Threading.Thread.Sleep(2000))
                .ContinueWith(task => 
                {
                    _isAExecuting = false;
                    RefreshCommands();
                }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private bool _isBExecuting;
        private void ExecuteB()
        {
            _isBExecuting = true;
            RefreshCommands();
            Task.Factory.StartNew(() => System.Threading.Thread.Sleep(3000))
                .ContinueWith(task =>
                {
                    _isBExecuting = false;
                    RefreshCommands();
                }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private bool _isCExecuting;
        private void ExecuteC()
        {
            _isCExecuting = true;
            RefreshCommands();
            Task.Factory.StartNew(() => System.Threading.Thread.Sleep(1000))
                .ContinueWith(task =>
                {
                    _isCExecuting = false;
                    RefreshCommands();
                }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void RefreshCommands()
        {
            CommandA.RaiseCanExecuteChanged();
            CommandB.RaiseCanExecuteChanged();
            CommandC.RaiseCanExecuteChanged();
        }
    }
