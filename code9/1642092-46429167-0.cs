    diff --git a/Weingartner.Json.Migration.Roslyn.Spec/Helpers/DiagnosticVerifier.Helper.cs b/Weingartner.Json.Migration.Roslyn.Spec/Helpers/DiagnosticVerifier.Helper.cs
    index da3b933..ba6cc7c 100644
    --- a/Weingartner.Json.Migration.Roslyn.Spec/Helpers/DiagnosticVerifier.Helper.cs
    +++ b/Weingartner.Json.Migration.Roslyn.Spec/Helpers/DiagnosticVerifier.Helper.cs
    @@ -28,6 +28,7 @@ namespace TestHelper
             private static readonly MetadataReference CSharpSymbolsReference = MetadataReference.CreateFromFile(typeof(CSharpCompilation).Assembly.Location);
             private static readonly MetadataReference CodeAnalysisReference = MetadataReference.CreateFromFile(typeof(Compilation).Assembly.Location);
             private static readonly MetadataReference SystemRuntimeReference = MetadataReference.CreateFromFile(Assembly.Load("System.Runtime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a").Location);
    +        private static readonly MetadataReference NetStandard = MetadataReference.CreateFromFile(Assembly.Load("netstandard, Version=2.0.0.0").Location);
             private static readonly MetadataReference MigrationReference = MetadataReference.CreateFromFile(typeof(MigratableAttribute).Assembly.Location);
             private static readonly MetadataReference SerializationReference = MetadataReference.CreateFromFile(typeof(DataMemberAttribute).Assembly.Location);
             private static readonly MetadataReference JsonNetReference = MetadataReference.CreateFromFile(typeof(Newtonsoft.Json.JsonConvert).Assembly.Location);
    @@ -169,6 +170,7 @@ namespace TestHelper
                     .AddMetadataReference(projectId, SystemRuntimeReference)
                     .AddMetadataReference(projectId, MigrationReference)
                     .AddMetadataReference(projectId, SerializationReference)
    +                .AddMetadataReference(projectId, NetStandard)
                     .AddMetadataReference(projectId, JsonNetReference);
                 var compilationOptions = solution
                     .GetProject(projectId)
