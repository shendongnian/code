        public virtual IFileInfo GetFileInfo(string subpath)
        {
            if (_HostingEnvironment != null)
            {
                var filepath = Path.Combine(_HostingEnvironment.ContentRootPath, subpath.TrimStart('/'));
                if (File.Exists(filepath))
                    return new NotFoundFileInfo(filepath);
            }
            return _EmbeddedFileProvider.GetFileInfo(subpath)
        }
    and add it to `Startup.ConfigureServices()`:
        services.Configure<RazorViewEngineOptions>(options =>
        {
            options.FileProviders.Add(new MyEmbeddedFileProvider(typeof(SomeTypeInTheTargetAssembly).GetTypeInfo().Assembly, HostingEnvironment));
            });
         }
