    using Microsoft.AspNetCore.Mvc;
    using Microsoft.DotNet.PlatformAbstractions;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyModel;
    using Microsoft.Extensions.DependencyModel.Resolution;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    
    namespace somenamespace
    {
        public class MvcConfiguration : IDesignTimeMvcBuilderConfiguration
        {
            private class DirectReferenceAssemblyResolver : ICompilationAssemblyResolver
            {
                public bool TryResolveAssemblyPaths(CompilationLibrary library, List<string> assemblies)
                {
                    if (!string.Equals(library.Type, "reference", StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
    
                    var paths = new List<string>();
    
                    foreach (var assembly in library.Assemblies)
                    {
                        var path = Path.Combine(ApplicationEnvironment.ApplicationBasePath, assembly);
    
                        if (!File.Exists(path))
                        {
                            return false;
                        }
    
                        paths.Add(path);
                    }
    
                    assemblies.AddRange(paths);
    
                    return true;
                }
            }
    
            public void ConfigureMvc(IMvcBuilder builder)
            {
                // .NET Core SDK v1 does not pick up reference assemblies so
                // they have to be added for Razor manually. Resolved for
                // SDK v2 by https://github.com/dotnet/sdk/pull/876 OR SO WE THOUGHT
                /*builder.AddRazorOptions(razor =>
                {
                    razor.AdditionalCompilationReferences.Add(
                        MetadataReference.CreateFromFile(
                            typeof(PdfHttpHandler).Assembly.Location));
                });*/
    
                // .NET Core SDK v2 does not resolve reference assemblies' paths
                // at all, so we have to hack around with reflection
                typeof(CompilationLibrary)
                    .GetTypeInfo()
                    .GetDeclaredField("<DefaultResolver>k__BackingField")
                    .SetValue(null, new CompositeCompilationAssemblyResolver(new ICompilationAssemblyResolver[]
                    {
                        new DirectReferenceAssemblyResolver(),
                        new AppBaseCompilationAssemblyResolver(),
                        new ReferenceAssemblyPathResolver(),
                        new PackageCompilationAssemblyResolver(),
                    }));
            }
        }
    }
