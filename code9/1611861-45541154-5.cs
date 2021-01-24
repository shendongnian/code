    class Program
    {
        static void Main(string[] args)
        {
            Do().Wait();
        }
        static async Task Do()
        {
            var ws = MSBuildWorkspace.Create();
            var project = await ws.OpenProjectAsync(@"..\..\DLaB.Xrm.Entities\DLaB.Xrm.Entities.csproj"); // initial DLaB.Xrm.Entities project from your github
            Task.WaitAll(new List<Task>(project.Documents.Select(Rewrite)).ToArray());
        }
        static async Task Rewrite(Document doc)
        {
            var tree = await doc.GetSyntaxTreeAsync();
            var root = await tree.GetRootAsync();
            var optimizer = new EntitySizeOptimizer();
            var result = optimizer.Visit(root);
            string dir = @"..\..\DLaB.Xrm.Entities2"; // a copy of DLaB.Xrm.Entities project to compare size
            string path = Path.Combine(dir, string.Join(@"\", doc.Folders), doc.Name);
            File.WriteAllText(path, result.ToFullString());
            Console.WriteLine(path);
        }
    }
    class EntitySizeOptimizer : CSharpSyntaxRewriter
    {
        // try the MyBaseEntity approach (note I just removed the OnPropXXX calls for testing, I've not created the whole base class, it's more work).
        static SyntaxNode Nop = SyntaxFactory.ParseExpression(""); // I'm sure there's something smarter than this...
        public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            string text = node.ToFullString().Trim();
            if (text.StartsWith("this.OnPropertyChang")) // bit of a hack...
                return Nop;
            return base.VisitInvocationExpression(node);
        }
        // remove Fields
        public override SyntaxNode VisitStructDeclaration(StructDeclarationSyntax node)
        {
            if (node.Identifier.ValueText == "Fields")
                return null;
            return base.VisitStructDeclaration(node);
        }
        // remove useless attributes
        public override SyntaxNode VisitAttributeList(AttributeListSyntax node)
        {
            var atts = new SeparatedSyntaxList<AttributeSyntax>().AddRange(FilterAttributes(node.Attributes));
            if (atts.Count == 0) // nothing left, remove this node
                return null;
            if (atts.Count == node.Attributes.Count) // no change, don't change the tree
                return base.VisitAttributeList(node);
            return node.WithAttributes(atts); // rewrite
        }
        private static IEnumerable<AttributeSyntax> FilterAttributes(IEnumerable<AttributeSyntax> atts)
        {
            foreach (var att in atts)
            {
                if (IsSameAttribute(att, typeof(EnumMemberAttribute).FullName))
                    continue;
                if (IsSameAttribute(att, typeof(DebuggerNonUserCodeAttribute).FullName))
                    continue;
                if (IsSameAttribute(att, typeof(GeneratedCodeAttribute).FullName))
                    continue;
                yield return att;
            }
        }
        private static bool IsSameAttribute(AttributeSyntax node, string text)
        {
            return node.Name is QualifiedNameSyntax qn && IsSameAttribute(text, qn.ToFullString());
        }
        // note: we could (should?) use Roslyn Semantic Model, but this is faster...
        private static bool IsSameAttribute(string att1, string att2)
        {
            if (att1 == att2)
                return true;
            string StripAttribute(string att)
            {
                const string token = "Attribute";
                return att.EndsWith(token) ? att.Substring(0, att.Length - token.Length) : att;
            }
            return StripAttribute(att1) == StripAttribute(att2);
        }
    }
 
