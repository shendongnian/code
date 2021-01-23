    public QualifiedNameSyntax Combine(NameSyntax left, NameSyntax right)
    {
      var qn = right as QualifiedNameSyntax;
      if (qn != null)
      {
        return SyntaxFactory.QualifiedName(Combine(left, qn.Left), qn.Right);
      }
      var sn = right as SimpleNameSyntax;
      if (sn != null)
      {
        return SyntaxFactory.QualifiedName(left, sn);
      }
      throw new NotSupportedException();
    }
