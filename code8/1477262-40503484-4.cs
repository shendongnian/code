    CompilerParameters parameters = new CompilerParameters();
    // Newly created assembly has to be a dll.
    parameters.GenerateExecutable = false;
    // Filename has to be like the original resourcename. Renaming afterwards does not work.
    parameters.OutputAssembly = "./de/TranslationTest.resources.dll";
    // Resourcefile has to be embedded in the new assembly.
    parameters.EmbeddedResources.Add(resourcefileName);
