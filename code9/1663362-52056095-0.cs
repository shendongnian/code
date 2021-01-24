    using System;
    using System.Collections.Immutable;
    using System.Composition;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CodeFixes;
    using Microsoft.CodeAnalysis.Diagnostics;
    
    namespace DisableSonarLint
    {
        [DiagnosticAnalyzer(LanguageNames.CSharp)]
        public class DisableSonarLintAnalyzer : DiagnosticAnalyzer
        {
            public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create<DiagnosticDescriptor>();
    
            public override void Initialize(AnalysisContext context)
            {
    
            }
        }
    
        [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(DisableSonarLintCodeFixProvider)), Shared]
        public class DisableSonarLintCodeFixProvider : CodeFixProvider
        {
            public override ImmutableArray<String> FixableDiagnosticIds => ImmutableArray.Create<string>();
    
            public override Task RegisterCodeFixesAsync(CodeFixContext context)
            {
                return Task.CompletedTask;
            }
        }
    }
