    using System;
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Diagnostics;
    using Microsoft.CodeAnalysis.Semantics;
    
    namespace Analyzer1
    {
        [DiagnosticAnalyzer(LanguageNames.CSharp)]
        public class LoggerAnalyzer : DiagnosticAnalyzer
        {
            public const string DiagnosticId = "Logging";
            internal const string Title = "Logging error";
            internal const string MessageFormat = "Logging error {0}";
            internal const string Description = "You should have the same amount of arguments in the logger as you do in the method.";
            internal const string Category = "Syntax";
    
            internal static DiagnosticDescriptor Rule =
              new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat,
              Category, DiagnosticSeverity.Error, isEnabledByDefault: true, description: Description);
    
            public override ImmutableArray<DiagnosticDescriptor>
              SupportedDiagnostics
            { get { return ImmutableArray.Create(Rule); } }
    
            public override void Initialize(AnalysisContext context)
            {
                context.RegisterSyntaxNodeAction(
                  AnalyzeNode, SyntaxKind.InvocationExpression);
            }
    
            private void AnalyzeNode(SyntaxNodeAnalysisContext context)
            {
                var invocationExpr = (InvocationExpressionSyntax)context.Node;
                var memberAccessExpr = invocationExpr.Expression as MemberAccessExpressionSyntax;
    
                if (memberAccessExpr != null && memberAccessExpr.Name.ToString() != "Log")
                {
                    return;
                }
    
                var memberSymbol =
                    context.SemanticModel.GetSymbolInfo(memberAccessExpr).Symbol as IMethodSymbol;
    
                if (memberSymbol == null || !memberSymbol.ToString().StartsWith("AnalyzerTest.Logger.Log"))
                {
                    return;
                }
    
                MethodDeclarationSyntax parent = GetParentMethod(context.Node);
                if(parent == null)
                {
                    return;
                }
    
                var argumentList = invocationExpr.ArgumentList;
    
                Int32 parentArgCount = parent.ParameterList.Parameters.Count;
                Int32 argCount = argumentList != null ? argumentList.Arguments.Count : 0;
    
                if (parentArgCount != argCount)
                {
                    var diagnostic = Diagnostic.Create(Rule, invocationExpr.GetLocation(), Description);
                    context.ReportDiagnostic(diagnostic);
                }
            }
    
            private MethodDeclarationSyntax GetParentMethod(SyntaxNode node)
            {
                var parent = node.Parent as MethodDeclarationSyntax;
                if(parent == null)
                {
                    return GetParentMethod(node.Parent);
                }
    
                return parent;
            }
        }
    }
