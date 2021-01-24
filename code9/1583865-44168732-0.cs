    public static SyntaxNode GetNodeFromLocation(this SyntaxTree tree, ReferenceLocation location)
    { 
        var lineSpan = location.Location.GetLineSpan();
        return tree.GetRoot().DescendantNodes().FirstOrDefault(n => n.GetLocation().GetLineSpan().IsEqual(lineSpan));
    }
