    using System;
    using System.Reflection;
    using static System.Reflection.BindingFlags;
    
    …
    
    var systemDirectory = typeof(Environment).GetProperty("SystemDirectory", NonPublic | Static)
        .GetValue(null, null);
