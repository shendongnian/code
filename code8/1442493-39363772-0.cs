    if (symbolInfo.Symbol == null &&
        symbolInfo.CandidateSymbols.IsEmpty &&
        symbolInfo.CandidateReason == CandidateReason.None) {
      var identifier = node.Expression as IdentifierNameSyntax;
      if (identifier != null && identifier.Identifier.Kind() == SyntaxKind.IdentifierToken && identifier.Identifier.Text == "nameof") {
        // We have a nameof expression
      }
    }
