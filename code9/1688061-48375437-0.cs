    let blackListedMethodNames = new [] {
      "System.IO.Directory.XXX",
      ...
    }.ToHashSet()
    
    let blackListedMethods =
    Methods.Where(m => blackListedMethodNames.Contains(m.FullName)).ToHashSet()
    
    from m in Application.Methods.UsingAny(blackListedMethods )
    select new { m, 
                 blackListedMethodsCalled = m.MethodsCalled.Intersect(blackListedMethods ) }
