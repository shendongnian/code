        using System.Web.Hosting;
    using System.Web.Caching;
    using System.Collections;
    using System;
    using System.IO;
    using System.Web;
    using System.Reflection;
    
    namespace AADGridView
    {
        public class AssemblyResourceProvider : VirtualPathProvider
        {
            string mResourcePrefix;
    
            public AssemblyResourceProvider() : this("EmbeddedWebResource")
            {
            }
    
            public AssemblyResourceProvider(string prefix)
            {
                mResourcePrefix = prefix;
            }
    
            private bool IsAppResourcePath(string virtualPath)
            {
                String checkPath = VirtualPathUtility.ToAppRelative(virtualPath);
                return checkPath.StartsWith("~/" + mResourcePrefix + "/",
                       StringComparison.InvariantCultureIgnoreCase);
            }
    
            public override bool FileExists(string virtualPath)
            {
                return (IsAppResourcePath(virtualPath) ||
                        base.FileExists(virtualPath));
            }
    
            public override VirtualFile GetFile(string virtualPath)
            {
                if (IsAppResourcePath(virtualPath))
                    return new AssemblyResourceVirtualFile(virtualPath);
                else
                    return base.GetFile(virtualPath);
            }
    
            public override CacheDependency
                   GetCacheDependency(string virtualPath,
                   IEnumerable virtualPathDependencies,
                   DateTime utcStart)
            {
                if (IsAppResourcePath(virtualPath))
                    return null;
                else
                    return base.GetCacheDependency(virtualPath,
                           virtualPathDependencies, utcStart);
            }
        }
    
        class AssemblyResourceVirtualFile : VirtualFile
        {
            string path;
    
            public AssemblyResourceVirtualFile(string virtualPath) : base(virtualPath)
            {
                path = VirtualPathUtility.ToAppRelative(virtualPath);
            }
    
            public override Stream Open()
            {
                string[] parts = path.Split('/');
                string assemblyName = parts[2];
                string resourceName = parts[3];
                assemblyName = Path.Combine(HttpRuntime.BinDirectory, assemblyName);
                Assembly assembly = Assembly.LoadFile(assemblyName);
                if (assembly == null) throw new Exception("Failed to load " + assemblyName);
                Stream s = assembly.GetManifestResourceStream(resourceName);
                if (s == null) throw new Exception("Failed to load " + resourceName);
                return s;
            }
        }
    }
