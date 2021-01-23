    public class FolderMonitor : IWQLMonitor
        {
            private const string _eventClassName = "__InstanceCreationEvent";
            *!*!*private const string _isaType = "Win32_Directory";*!*!*
    
            private readonly IEventListenerManager _eListenerManager;
            private readonly IFileProcessService _fileProcessService;
    
            public WqlEventQuery Query { get; }
            public string Path { get; }
    
            public FolderMonitor(string path, IEventListenerManager eListenerManager, IFileProcessService fileProcessService)
            {
                _eListenerManager = eListenerManager;
                _fileProcessService = fileProcessService;
    
                if (string.IsNullOrEmpty(path))
                    path = GetConfiguredDirectory();
    
                Path = path;
    
                *!*!*var drive = Path.Substring(0, 2);*!*!*
                *!*!*var queryPath = Path.Substring(2) + @"\";*!*!*
    
                var queryParamPath = queryPath.Replace(@"\", @"\\");
    
                Query = new WqlEventQuery
                {
                    EventClassName = _eventClassName,
                    *!*!*Condition = $"TargetInstance Isa '{_isaType}' And TargetInstance.Drive = '{drive}' And TargetInstance.Path = '{queryParamPath}'",*!*!*
                    WithinInterval = new TimeSpan(0,0,1)
                };
            } 
        }
