    #if NETSTANDARD1_2
    using Some.NetStandardOnly.Namespace;
    #endif
    using System;
    
    #if NET451
    public DataTable GetDataTable() 
    {
        ...
    }
    #endif
