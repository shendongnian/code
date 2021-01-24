    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;
    using VSLangProj80;
    [ComVisible(true)]
    [Guid("your-unique-identifier")]
    [CodeGeneratorRegistration(
        typeof(MyCustomTool),
        "MyCustomTool",
        vsContextGuids.vsContextGuidVCSProject,
        GeneratesDesignTimeSource = true,
        GeneratorRegKeyName = "MyCustomTool"
    )]
    [ProvideObject(
        typeof(MyCustomTool),
        RegisterUsing = RegistrationMethod.CodeBase
    )]
    public sealed class MyCustomTool : IVsSingleFileGenerator {
