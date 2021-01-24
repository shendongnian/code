    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Diagnostics;
    using System.Collections.Immutable;
    using System.Diagnostics;
    using System.Linq;
    
    namespace NonAsciiAnalyzer
    {
        [DiagnosticAnalyzer(LanguageNames.CSharp)]
        public class NonAsciiAnalyzerAnalyzer : DiagnosticAnalyzer
        {
            public const string DiagnosticId = "NonAsciiAnalyzer";
    
            // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
            private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
            private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
            private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
            private const string Category = "Naming";
    
            private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);
    
            public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }
    
            public override void Initialize(AnalysisContext context)
            {
                context.RegisterSyntaxNodeAction(AnalyzeNamespaceDeclaration, SyntaxKind.NamespaceDeclaration);
                context.RegisterSyntaxNodeAction(AnalyzeInterfaceDeclaration, SyntaxKind.InterfaceDeclaration);
                context.RegisterSyntaxNodeAction(AnalyzeClassDeclaration, SyntaxKind.ClassDeclaration);
                context.RegisterSyntaxNodeAction(AnalyzeStructDeclaration, SyntaxKind.StructDeclaration);
                context.RegisterSyntaxNodeAction(AnalyzeDelegateDeclaration, SyntaxKind.DelegateDeclaration);
                context.RegisterSyntaxNodeAction(AnalyzeEnumDeclaration, SyntaxKind.EnumDeclaration);
                context.RegisterSyntaxNodeAction(AnalyzeEnumMemberDeclaration, SyntaxKind.EnumMemberDeclaration);
                context.RegisterSyntaxNodeAction(AnalyzeFieldDeclaration, SyntaxKind.FieldDeclaration);
                context.RegisterSyntaxNodeAction(AnalyzeEventDeclaration, SyntaxKind.EventDeclaration);
                context.RegisterSyntaxNodeAction(AnalyzePropertyDeclaration, SyntaxKind.PropertyDeclaration);
                context.RegisterSyntaxNodeAction(AnalyzeMethodDeclaration, SyntaxKind.MethodDeclaration);
    
                context.RegisterSyntaxNodeAction(AnalyzeUsingDirective, SyntaxKind.UsingDirective);
                context.RegisterSyntaxNodeAction(AnalyzeExternAliasDirective, SyntaxKind.ExternAliasDirective);
    
                context.RegisterSyntaxNodeAction(AnalyzeTypeParameter, SyntaxKind.TypeParameter);
                context.RegisterSyntaxNodeAction(AnalyzeParameter, SyntaxKind.Parameter);
                context.RegisterSyntaxNodeAction(AnalyzeVariableDeclaration, SyntaxKind.VariableDeclaration);
                context.RegisterSyntaxNodeAction(AnalyzeLabelStatement, SyntaxKind.LabeledStatement);
                context.RegisterSyntaxNodeAction(AnalyzeCatchDeclaration, SyntaxKind.CatchDeclaration);
                context.RegisterSyntaxNodeAction(AnalyzeForEachStatement, SyntaxKind.ForEachStatement);
                context.RegisterSyntaxNodeAction(AnalyzeAnonymousObjectMemberDeclarator, SyntaxKind.AnonymousObjectMemberDeclarator);
    
                context.RegisterSyntaxNodeAction(AnalyzeFromClause, SyntaxKind.FromClause);
                context.RegisterSyntaxNodeAction(AnalyzeLetClause, SyntaxKind.LetClause);
                context.RegisterSyntaxNodeAction(AnalyzeJoinClause, SyntaxKind.JoinClause);
                context.RegisterSyntaxNodeAction(AnalyzeJoinIntoClause, SyntaxKind.JoinIntoClause);
                context.RegisterSyntaxNodeAction(AnalyzeQueryContinuation, SyntaxKind.QueryContinuation);
            }
    
            private void AnalyzeNamespaceDeclaration(SyntaxNodeAnalysisContext context)
            {
                var nds = (NamespaceDeclarationSyntax)context.Node;
                var sns = (SimpleNameSyntax)nds.Name;
                string name = sns.Identifier.Text;
                Debug.WriteLine("Namespace: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeInterfaceDeclaration(SyntaxNodeAnalysisContext context)
            {
                var ids = (InterfaceDeclarationSyntax)context.Node;
                string name = ids.Identifier.Text;
                Debug.WriteLine("Interface: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeClassDeclaration(SyntaxNodeAnalysisContext context)
            {
                var cds = (ClassDeclarationSyntax)context.Node;
                string name = cds.Identifier.Text;
                Debug.WriteLine("Class: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeStructDeclaration(SyntaxNodeAnalysisContext context)
            {
                var sds = (StructDeclarationSyntax)context.Node;
                string name = sds.Identifier.Text;
                Debug.WriteLine("Struct: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeDelegateDeclaration(SyntaxNodeAnalysisContext context)
            {
                var dds = (DelegateDeclarationSyntax)context.Node;
                string name = dds.Identifier.Text;
                Debug.WriteLine("Delegate: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeEnumDeclaration(SyntaxNodeAnalysisContext context)
            {
                var eds = (EnumDeclarationSyntax)context.Node;
                string name = eds.Identifier.Text;
                Debug.WriteLine("Enum: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeEnumMemberDeclaration(SyntaxNodeAnalysisContext context)
            {
                var emds = (EnumMemberDeclarationSyntax)context.Node;
                string name = emds.Identifier.Text;
                Debug.WriteLine("Enum Member: " + name);
                Check(context, name, Rule);
            }
    
            // Already done by LocalDeclaration
            private void AnalyzeFieldDeclaration(SyntaxNodeAnalysisContext context)
            {
                //var fds = (FieldDeclarationSyntax)context.Node;
    
                //foreach (var fds2 in fds.Declaration.Variables)
                //{
                //    string name = fds2.Identifier.Text;
                //    Debug.WriteLine("Field: " + name);
                //    Check(context, name, Rule);
                //}
            }
    
            private void AnalyzeEventDeclaration(SyntaxNodeAnalysisContext context)
            {
                var eds = (EventDeclarationSyntax)context.Node;
                string name = eds.Identifier.Text;
                Debug.WriteLine("Event: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzePropertyDeclaration(SyntaxNodeAnalysisContext context)
            {
                var pds = (PropertyDeclarationSyntax)context.Node;
                string name = pds.Identifier.Text;
                Debug.WriteLine("Property: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeMethodDeclaration(SyntaxNodeAnalysisContext context)
            {
                var mds = (MethodDeclarationSyntax)context.Node;
                string name = mds.Identifier.Text;
                Debug.WriteLine("Method: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeUsingDirective(SyntaxNodeAnalysisContext context)
            {
                var uds = (UsingDirectiveSyntax)context.Node;
    
                if (uds.Alias == null)
                {
                    return;
                }
    
                string name = uds.Alias.Name.Identifier.Text;
                Debug.WriteLine("Using Alias: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeExternAliasDirective(SyntaxNodeAnalysisContext context)
            {
                var eads = (ExternAliasDirectiveSyntax)context.Node;
                string name = eads.Identifier.Text;
                Debug.WriteLine("Extern Alias: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeTypeParameter(SyntaxNodeAnalysisContext context)
            {
                var tps = (TypeParameterSyntax)context.Node;
                string name = tps.Identifier.Text;
                Debug.WriteLine("Type Parameter: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeParameter(SyntaxNodeAnalysisContext context)
            {
                var ps = (ParameterSyntax)context.Node;
                string name = ps.Identifier.Text;
                Debug.WriteLine("Parameter: " + name);
                Check(context, name, Rule);
            }
    
            // Fields/const fields/local variables/local functions
            private void AnalyzeVariableDeclaration(SyntaxNodeAnalysisContext context)
            {
                var vds = (VariableDeclarationSyntax)context.Node;
    
                foreach (var vds2 in vds.Variables)
                {
                    string name = vds2.Identifier.Text;
                    Debug.WriteLine("Local: " + name);
                    Check(context, name, Rule);
                }
            }
    
            private void AnalyzeLabelStatement(SyntaxNodeAnalysisContext context)
            {
                var lss = (LabeledStatementSyntax)context.Node;
                string name = lss.Identifier.Text;
                Debug.WriteLine("Label: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeCatchDeclaration(SyntaxNodeAnalysisContext context)
            {
                var cds = (CatchDeclarationSyntax)context.Node;
                string name = cds.Identifier.Text;
                Debug.WriteLine("Catch Variable: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeForEachStatement(SyntaxNodeAnalysisContext context)
            {
                var fess = (ForEachStatementSyntax)context.Node;
                string name = fess.Identifier.Text;
                Debug.WriteLine("ForEach Variable: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeAnonymousObjectMemberDeclarator(SyntaxNodeAnalysisContext context)
            {
                var aqns = (AnonymousObjectMemberDeclaratorSyntax)context.Node;
                string name = aqns.NameEquals.Name.Identifier.Text;
                Debug.WriteLine("Anonymous Field: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeFromClause(SyntaxNodeAnalysisContext context)
            {
                var fcs = (FromClauseSyntax)context.Node;
                string name = fcs.Identifier.Text;
                Debug.WriteLine("From: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeLetClause(SyntaxNodeAnalysisContext context)
            {
                var lcs = (LetClauseSyntax)context.Node;
                string name = lcs.Identifier.Text;
                Debug.WriteLine("Let: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeJoinClause(SyntaxNodeAnalysisContext context)
            {
                var jcs = (JoinClauseSyntax)context.Node;
                string name = jcs.Identifier.Text;
                Debug.WriteLine("Join: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeJoinIntoClause(SyntaxNodeAnalysisContext context)
            {
                var jics = (JoinIntoClauseSyntax)context.Node;
                string name = jics.Identifier.Text;
                Debug.WriteLine("Join Into: " + name);
                Check(context, name, Rule);
            }
    
            private void AnalyzeQueryContinuation(SyntaxNodeAnalysisContext context)
            {
                var qcs = (QueryContinuationSyntax)context.Node;
                string name = qcs.Identifier.Text;
                Debug.WriteLine("Into: " + name);
                Check(context, name, Rule);
            }
    
            private void Check(SyntaxNodeAnalysisContext context, string name, DiagnosticDescriptor rule)
            {
                // .NET Core, with full .NET no .ToCharArray()
                if (name.ToCharArray().Any(x => x > 0x7f))
                {
                    // For all such symbols, produce a diagnostic.
                    var diagnostic = Diagnostic.Create(rule, context.Node.GetLocation(), name);
                    context.ReportDiagnostic(diagnostic);
                }
            }
        }
    }
