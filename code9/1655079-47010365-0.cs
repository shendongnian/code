      public class PsInvoker
      {
    
        public static PSObject[] InvokeCommand(string commandName, Hashtable parameters)
        {
          var sb = ScriptBlock.Create("param($Command, $Params) & $Command @Params");
          return sb.Invoke(commandName, parameters).ToArray();
        }
    
        public static PSObject[] InvokeCommand<T>(Hashtable parameters) where T : Cmdlet
        {
          return InvokeCommand(Extensions.GetCmdletName<T>(), parameters);
        }
    
        public static PsInvoker Create(string cmdletName)
        {
          return new PsInvoker(cmdletName);
        }
    
        public static PsInvoker Create<T>() where T : Cmdlet
        {
          return new PsInvoker(Extensions.GetCmdletName<T>());
        }
    
    
        private Hashtable Parameters { get; set; }
    
    
        public string CmdletName { get; }
    
        public bool Invoked { get; private set; }
    
        public PSObject[] Result { get; private set; }
    
    
        private PsInvoker(string cmdletName)
        {
          CmdletName = cmdletName;
          Parameters = new Hashtable();
        }
    
    
        public void AddArgument(string name, object value)
        {
          Parameters.Add(name, value);
        }
    
        public void AddArgument(string name)
        {
          Parameters.Add(name, null);
        }
    
        public PSObject[] Invoke()
        {
          if (Invoked)
            throw new InvalidOperationException("This instance has already been invoked.");
          var sb = ScriptBlock.Create("param($Command, $Params) & $Command @Params");
          Result = sb.Invoke(CmdletName, Parameters).ToArray();
          Invoked = true;
          return Result;
        }
    
      }
