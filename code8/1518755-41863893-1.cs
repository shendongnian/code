    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Mvvm;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    
    namespace Stackoverflow
    {
        public class MainWindowViewModel : BindableBase
        {
            private string _FrameSource;
    
            public MainWindowViewModel()
            {
                NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecute);
            }
    
            public string FrameSource
            {
                get { return _FrameSource; }
                set { SetProperty(ref _FrameSource, value); }
            }
    
            public ICommand NavigateCommand { get; private set; }
    
            private void OnNavigateCommandExecute(string frameSource)
            {
                FrameSource = frameSource;
            }
        }
    }
