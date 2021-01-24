    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    
    namespace Roslyn
    {
        internal class Program
        {
            private static void Main()
            {
                var tree = CSharpSyntaxTree.ParseText(@"
    class C1{
       private int var1;
       public string var2;
    
       void action1()
        {
           int var3;
           var3=var1*var1;
           var2=""Completed"";
       }
    }
    ");
                var root = (CompilationUnitSyntax) tree.GetRoot();
                var variableDeclarations = root.DescendantNodes().OfType<VariableDeclarationSyntax>();
    
                Console.WriteLine("Declare variables:");
    
                foreach (var variableDeclaration in variableDeclarations)
                    Console.WriteLine(variableDeclaration.Variables.First().Identifier.Value);
    
                var variableAssignments = root.DescendantNodes().OfType<AssignmentExpressionSyntax>();
    
                Console.WriteLine("Assign variables:");
    
                foreach (var variableAssignment in variableAssignments)
                    Console.WriteLine($"Left: {variableAssignment.Left}, Right: {variableAssignment.Right}");
            }
        }
    }
