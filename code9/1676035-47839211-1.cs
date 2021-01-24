    byte[] assemblyBytes = DownloadAssembly();
    using (var interactiveLoader = new InteractiveAssemblyLoader()) {
        interactiveLoader.RegisterDependency(Assembly.Load(assemblyBytes));
        var script = CSharpScript.Create<string>(
            scriptText,
            globalsType: typeof(Globals),
            options: ScriptOptions.Default.AddReferences(MetadataReference.CreateFromStream(new MemoryStream(assemblyBytes))),
            assemblyLoader: interactiveLoader
        );
        script.Compile();
        var result = await script.RunAsync(globals);
    }
