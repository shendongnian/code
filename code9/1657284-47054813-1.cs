    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using AgentOctal.WpfLib;
    using AgentOctal.WpfLib.Commands;
    
    namespace BindingHelp
    {
        class MainWindowVm : ViewModel
        {
            private string _value;
            public string Value
            {
                get { return _value; }
                set
                {
                    if (SetValue(ref _value, value))
                    {
                        ShouldAnimate = true;
                    }
                }
            }
    
            private bool _shouldAnimate = false;
            public bool ShouldAnimate
            {
                get { return _shouldAnimate; }
                set { SetValue(ref _shouldAnimate, value); }
            }
    
    
            private ICommand _setValueCommand;
            public ICommand SetValueCommand
            {
                get
                {
                    return _setValueCommand ?? (_setValueCommand = new SimpleCommand((obj) =>
                    {
                        Value = "This is a test!";
                    }));
                }
            }    
        }
    }
