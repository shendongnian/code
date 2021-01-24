    static int Main(string[] args)
    {
        if ( !File.Exists( @"E:\Ivara\Cache\TimeCacheLastUpdated.txt" ) )
        {
            return -99;
        }
        return 6;
    }
    
    #if !VISUAL_STUDIO
    class CsScriptExitException: Exception
    {
    	public CsScriptExitException(string message, int exitCode)
    		:base(message)
    	{
    		this.HResult = exitCode;
    	}
    }
    
    int scriptExitCode = Main(Args.ToArray());
    
    if (scriptExitCode != 0)
    {
        throw new CsScriptExitException($"Script exit code: {scriptExitCode}.", scriptExitCode);
    }
    #endif
