    private class RegionSyntaxRewriter : CSharpSyntaxRewriter
    {
        int currentPosition = 0;
        private List<int> EndRegionsForDeletion = new List<int>();
        private string deletedRegion;
        private bool useRegionNameForAnalysis = false;
        public RegionSyntaxRewriter(string deletedRegion) : base(true)
        {
            this.deletedRegion = deletedRegion;
        }
        public override SyntaxNode VisitRegionDirectiveTrivia(
                RegionDirectiveTriviaSyntax node)
        {
            currentPosition++;
            var regionText = node.ToFullString().Substring(8).Trim();
            if (!useRegionNameForAnalysis &&
                node.ParentTrivia.Token.Parent is ClassDeclarationSyntax)
            {
                EndRegionsForDeletion.Add(currentPosition);
                return SyntaxFactory.SkippedTokensTrivia();
            }
            if (useRegionNameForAnalysis && 
                regionText == deletedRegion)
            {
                EndRegionsForDeletion.Add(currentPosition);
                return SyntaxFactory.SkippedTokensTrivia();
            }
            return base.VisitRegionDirectiveTrivia(node);
        }
        public override SyntaxNode VisitEndRegionDirectiveTrivia(
                EndRegionDirectiveTriviaSyntax node)
        {
            var oldPosition = currentPosition;
            currentPosition--;
            if (EndRegionsForDeletion.Contains(oldPosition))
            {
                EndRegionsForDeletion.Remove(currentPosition);
                return SyntaxFactory.SkippedTokensTrivia();
            }
            return base.VisitEndRegionDirectiveTrivia(node);
        }
    }
