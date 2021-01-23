    try
    {
        try { a; } 
        catch { b; }  // All catch clauses would be here...
    }
    catch
    {
         c;      // code that was in finally block.
         throw;  // rethrow same exception
    }
