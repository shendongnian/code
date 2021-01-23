    public class MachineWideSettings : IMachineWideSettings
    {
    	private readonly Lazy<IEnumerable<Settings>> _settings;
    
    	public MachineWideSettings()
    	{
    		var baseDirectory = NuGetEnvironment.GetFolderPath(NuGetFolderPath.MachineWideConfigDirectory);
    		_settings = new Lazy<IEnumerable<Settings>>(
    			() => global::NuGet.Configuration.Settings.LoadMachineWideSettings(baseDirectory));
    	}
    
    	public IEnumerable<Settings> Settings => _settings.Value;
    }
    
    public class Logger : ILogger
    {
    	private List<string> logs = new List<string>();
    
    	public void LogDebug(string data)
    	{
    		logs.Add(data);
    	}
    
    	public void LogVerbose(string data)
    	{
    		logs.Add(data);
    	}
    
    	public void LogInformation(string data)
    	{
    		logs.Add(data);
    	}
    
    	public void LogMinimal(string data)
    	{
    		logs.Add(data);
    	}
    
    	public void LogWarning(string data)
    	{
    		logs.Add(data);
    	}
    
    	public void LogError(string data)
    	{
    		logs.Add(data);
    	}
    
    	public void LogInformationSummary(string data)
    	{
    		logs.Add(data);
    	}
    
    	public void LogErrorSummary(string data)
    	{
    		logs.Add(data);
    	}
    }
    
    public class ProjectContext : INuGetProjectContext
    {
    	private List<string> logs = new List<string>();
    
    	public List<string> GetLogs()
    	{
    		return logs;
    	}
    
    	public void Log(MessageLevel level, string message, params object[] args)
    	{
    		var formattedMessage = String.Format(message, args);
    		logs.Add(formattedMessage);
    		// Do your logging here...
    	}
    
    	public FileConflictAction ResolveFileConflict(string message)
    	{
    		logs.Add(message);
    		return FileConflictAction.Ignore;
    	}
    
    
    	public PackageExtractionContext PackageExtractionContext
    	{
    		get;
    		set;
    	}
    
    	public NuGet.ProjectManagement.ExecutionContext ExecutionContext
    	{
    		get;
    	}
    
    	public XDocument OriginalPackagesConfig
    	{
    		get; set;
    	}
    
    	public ISourceControlManagerProvider SourceControlManagerProvider
    	{
    		get;
    		set;
    	}
    
    	public void ReportError(string message)
    	{
    		logs.Add(message);
    	}
    
    	public NuGetActionType ActionType
    	{
    		get; set;
    	}
    
    	public TelemetryServiceHelper TelemetryService
    	{
    		get; set;
    	}
    }
