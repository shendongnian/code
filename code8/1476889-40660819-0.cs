    static void Main(string[] args)
    {
      var solutionPath = @"D:\Development\lams\src\Lams.sln";
      var workspace = MSBuildWorkspace.Create();
      var solution = workspace.OpenSolutionAsync(solutionPath).Result;
      var documents = solution.Projects.SelectMany(x => x.Documents).Select(x => x.Id).ToList();
      foreach (var documentId in documents)
      {
        Console.WriteLine(solution.GetDocument(documentId).Name);
        while (true)
        {
          var doc = solution.GetDocument(documentId);
          var model = doc.GetSemanticModelAsync().Result;
          var syntax = doc.GetSyntaxRootAsync().Result;
          var parameters = syntax.DescendantNodes()
            .OfType<ParameterSyntax>()
            .Where(x => Regex.IsMatch(x.Identifier.ValueText, @"(in|tmp|out)([A-Z])(\w+)"))
            .ToList();
          Console.Write($"{parameters.Count} ");
          var parameter = parameters.FirstOrDefault();
          if (parameter == null)
            break;
          string name = parameter.Identifier.ValueText;
          name = Regex.Replace(name, @"(in|tmp|out)([A-Z])(\w+)", m => m.Groups[2].Value.ToLower() + m.Groups[3].Value.ToString());
          var symbol = model.GetDeclaredSymbol(parameter);
          
          solution = Renamer.RenameSymbolAsync(solution, symbol, name, null).Result;
        }
        Console.WriteLine();
      }
      foreach (var documentId in documents)
      {
        Console.WriteLine(solution.GetDocument(documentId).Name);
        while (true)
        {
          var doc = solution.GetDocument(documentId);
          var model = doc.GetSemanticModelAsync().Result;
          var syntax = doc.GetSyntaxRootAsync().Result;
          var variables = syntax.DescendantNodes()
            .OfType<VariableDeclarationSyntax>().SelectMany(x => x.Variables)
            .Where(x => Regex.IsMatch(x.Identifier.ValueText, @"(in|tmp|out)([A-Z])(\w+)"))
            .ToList();
          Console.Write($"{variables.Count} ");
          var variable = variables.FirstOrDefault();
          if (variable == null)
            break;
          string name = variable.Identifier.ValueText;
          name = Regex.Replace(name, @"(in|tmp|out)([A-Z])(\w+)", m => m.Groups[2].Value.ToLower() + m.Groups[3].Value.ToString());
          var symbol = model.GetDeclaredSymbol(variable);
          solution = Renamer.RenameSymbolAsync(solution, symbol, name, null).Result;
        }
        Console.WriteLine();
      }
      //var canChange = solution.Workspace.CanApplyChange(ApplyChangesKind.ChangeDocument);
      solution.Workspace.TryApplyChanges(solution);
    }
