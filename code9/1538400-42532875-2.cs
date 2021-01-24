    #if NETSTANDARD1_2
    using Some.Net451Only.Namespace;
    #endif
    using System;
    
    #if NETSTANDARD1_2
    public DataTable GetDataTable() 
    {
        ...
    }
    #endif
