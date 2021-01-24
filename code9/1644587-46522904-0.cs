    using System.Runtime.CompilerServices;
    using System.Security;
    using System.Security.Permissions;
    
    [assembly: AssemblyVersion("0.0.0.0")]
    [assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
    [assembly: CompilationRelaxations(8)]
    [assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
    [assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
    [module: UnverifiableCode]
    namespace DatabaseModules
    {
        public class Test
        {
            public IList<string> _cache = new List<string>();
    
            public IList<string> Get
            {
                get
                {
                    return this._cache;
                }
            }
    
            public IList<string> GetOld
            {
                get
                {
                    return this._cache;
                }
            }
        }
    }
