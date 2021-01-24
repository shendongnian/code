    using System;
    using System.Reactive.Linq;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using System.Collections.ObjectModel;
    
    namespace Sandbox
    {
    
        public class SandboxNotifiableViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> projection)
            {
                var memberExpression = (MemberExpression) projection.Body;
                this.RaisePropertyChanged(memberExpression.Member.Name);
            }
    
            public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
                => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public class TestViewModel : SandboxNotifiableViewModel
        {
            private class SandBoxCommand : ICommand
            {
                private readonly Action cbk;
                public event EventHandler CanExecuteChanged;
    
                private void WarningRemover()
                    => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    
                public SandBoxCommand(Action cbk)
                {
                    this.cbk = cbk;
                }
    
                public bool CanExecute(object parameter)
                    => true;
                public void Execute(object parameter)
                    => this.cbk?.Invoke();
            }
    
            public TestViewModel()
            {
                this.AddLongTask = new SandBoxCommand(this.AddLongTaskAction);
                this.LongTasks = new ObservableCollection<LongTaskViewModel>();
            }
    
            public ObservableCollection<LongTaskViewModel> LongTasks { get; }
    
            private void AddLongTaskAction()
                => this.LongTasks.Add(new LongTaskViewModel());
    
            public ICommand AddLongTask { get; } 
        }
    
        public class LongTaskViewModel : SandboxNotifiableViewModel
        {
            private bool isFinished;
            private int progress;
    
    
            public LongTaskViewModel()
            {
                this.Progress = 0;
                this.IsFinished = false;
                // Refresh progress every 10ms 100 times 
                Observable.Interval(TimeSpan.FromMilliseconds(10))
                    .Select(x => x + 1) // 1 to 100
                    .Take(100)
                    // Here we make sure observable callback is called on dispatcher thread
                    .ObserveOnDispatcher()
                    .SubscribeOnDispatcher()
                    .Subscribe(this.OnProgressReported, this.OnLongTaskFinished);
            }
    
            public bool IsFinished
            {
                get => this.isFinished;
                set
                {
                    this.isFinished = value;
                    this.RaisePropertyChanged();
                }
            }
    
            public int Progress
            {
                get => this.progress;
                set
                {
                    this.progress = value;
                    this.RaisePropertyChanged();
                }
    
            }
    
            public void OnProgressReported(long dummyval)
            {
                this.Progress = (int) dummyval;
            }
    
            public void OnLongTaskFinished()
            {
                this.IsFinished = true;
            }
        }
    }
I used [Rx.NET][2] to handle async notifications (here progress emulation) and [MaterialDesignInXamlToolkit][3] for the global styling
  [1]: https://i.stack.imgur.com/83sU6.gif
  [2]: https://github.com/Reactive-Extensions/Rx.NET
  [3]: https://github.com/ButchersBoy/MaterialDesignInXamlToolkit
