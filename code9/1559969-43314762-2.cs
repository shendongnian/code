        public virtual IFileInfo GetFileInfo(string subpath)
            {
                if (_HostingEnvironment != null)
                {
                    var filepath = Path.Combine(_HostingEnvironment.ContentRootPath, subpath.TrimStart('/'));
                    if (File.Exists(filepath))
                        return new NotFoundFileInfo(filepath);
                }
                return _EmbeddedFileProvider.GetFileInfo(subpath);
            }
