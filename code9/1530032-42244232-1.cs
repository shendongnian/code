    public class User
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
        public string Login { get; set; }
     
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public FullName Name { get; set; }
     
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string HashedPassword { get; set; }
    }
