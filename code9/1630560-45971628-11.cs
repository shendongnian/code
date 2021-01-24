    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Xaml;
    using AgentOctal.WpfLib;
    using AgentOctal.WpfLib.Commands;
    using AgentOctal.WpfLib.Services;
    using AgentOctal.WpfLib.Services.Message;
    
    namespace RenamableTabs
    {
        class DocumentVm : ViewModel
        {
            public DocumentVm()
            {
                _messageService = ServiceManager.GetService<AgentOctal.WpfLib.Services.Message.IMessageService>();
            }
    
            private IMessageService _messageService;
    
            private string _name;
            public string Name
            {
                get { return _name; }
                set { SetValue(ref _name, value); }
            }
    
            private ICommand _renameCommand;
            public ICommand RenameCommand
            {
                get
                {
                    return _renameCommand ?? (_renameCommand = new SimpleCommand((obj) =>
                    {
                        _messageService.SendMessage(new DocumentRenaming() { Document = this });
                    }));
                }
            }
    
            private bool _isRenaming = false;
            public bool IsRenaming
            {
                get { return _isRenaming; }
                set { SetValue(ref _isRenaming, value); }
            }
    
            public class DocumentRenaming : IMessage
            {
                public DocumentVm Document { get; set; }
            }
        }
    }
