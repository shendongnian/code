    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AgentOctal.WpfLib;
    using AgentOctal.WpfLib.Services;
    using AgentOctal.WpfLib.Services.Message;
    
    namespace RenamableTabs
    {
        class MainWindowVm : ViewModel
        {
            public MainWindowVm()
            {
                _messageService = ServiceManager.GetService<AgentOctal.WpfLib.Services.Message.IMessageService>();
                _messageService.Subscribe<DocumentVm.DocumentRenaming>(message =>
                {
                    var m = message as DocumentVm.DocumentRenaming;
                    foreach (var documentVm in Documents)
                    {
                        documentVm.IsRenaming = documentVm == m.Document;
                    }
                });
    
                Documents = new ObservableCollection<DocumentVm>();
    
                Documents.Add(new DocumentVm() { Name = "Document 1" });
                Documents.Add(new DocumentVm() { Name = "Document 2" });
                Documents.Add(new DocumentVm() { Name = "Document 3" });
            }
    
            private IMessageService _messageService;
    
            public ObservableCollection<DocumentVm> Documents { get; }
    
            private string _name;
    
            public string Name
            {
                get {return _name;}
                set {SetValue(ref _name, value);}
            }
    
        }
    }
