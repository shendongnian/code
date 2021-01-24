    /// <summary>
    /// Rewrite a using statement into a try finally statement.  Two forms are possible:
    ///   1) using (expr) stmt
    ///   2) using (C c = expr) stmt
    ///   
    /// The former is handled by RewriteExpressionUsingStatement and the latter is handled by
    /// RewriteDeclarationUsingStatement (called in a loop, once for each local declared).
    /// </summary>
