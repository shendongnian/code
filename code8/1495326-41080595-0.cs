    SyntaxTree tree = CSharpSyntaxTree.ParseText(
        @"using System;
        return 1;", new CSharpParseOptions(LanguageVersion.CSharp6, DocumentationMode.Parse, SourceCodeKind.Script)
    );
    var root = (CompilationUnitSyntax)tree.GetRoot();
    var global = SyntaxFactory.GlobalStatement(SyntaxFactory.ParseStatement("var xyz = 123;"));
    root = root.InsertNodesBefore(root.Members.First(), new SyntaxNode[] { global });
