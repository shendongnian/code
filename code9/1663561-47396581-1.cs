    public class MyCmdletBase : PSCmdlet, ILogger
    {
        public void Verbose(string message) => WriteVerbose(message);
        
        public void Debug(string message) => WriteDebug(message);
  
        // etc.
    }
