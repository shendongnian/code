    var ns = objectCreationExpressionSyntax.Type as NameSyntax;
    if (ns != null)
    {
      return ns.Identifier.ToString();
    }
    var pts = objectCreationExpressionSyntax.Type as PredefinedTypeSyntax;
    if (pts != null)
    {
      return pts.Keyword.ToString();
    }
    ... 
