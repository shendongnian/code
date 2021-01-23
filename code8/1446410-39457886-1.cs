	// create tree, and semantic model
	var tree = CSharpSyntaxTree.ParseText(@"
		using System;
		public class Program
		{
		   public static void Main()
		   {
		      Console.WriteLine(""Hello World"");
		   }
	   }");
	var root = tree.GetRoot();
	
	var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
	var compilation = CSharpCompilation.Create("SO-39451235", syntaxTrees: new[] { tree }, references: new[] { mscorlib });
	var model = compilation.GetSemanticModel(tree);
	
	// get the nodes refered to in the SO question
	
	var usingSystemDirectiveNode = root.DescendantNodes().OfType<UsingDirectiveSyntax>().Single();
	var consoleWriteLineInvocationNode = root.DescendantNodes().OfType<InvocationExpressionSyntax>().Single();
	
	// retrieve symbols related to the syntax nodes
	
	var writeLineMethodSymbol = (IMethodSymbol)model.GetSymbolInfo(consoleWriteLineInvocationNode).Symbol;
	var namespaceOfWriteLineMethodSymbol = (INamespaceSymbol)writeLineMethodSymbol.ContainingNamespace;
	
	var usingSystemNamespaceSymbol = model.GetSymbolInfo(usingSystemDirectiveNode.Name).Symbol;
	
	// check the namespace symbols for equality, this will return true
	
	namespaceOfWriteLineMethodSymbol.Equals(usingSystemNamespaceSymbol).Dump();
