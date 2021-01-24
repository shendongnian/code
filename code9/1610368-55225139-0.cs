    public static class SyntaxHelpers
    {
        public static T GenerateClassNode<T>(string decl) where T : CSharpSyntaxNode
        {
            var declaration = SyntaxFactory.ParseCompilationUnit(
                " public class FSM { \r\n" +
                $"{decl}\r\n" +
                " }} \r\n");
    
            var field = declaration.Members[0].DescendantNodes().First() as T;
            return field;
        }
    }
