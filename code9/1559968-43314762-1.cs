        public virtual IFileInfo GetFileInfo(string subpath)
            {
                if (_HostingEnvironment != null)
                {
                    var filepath = Strings.Append(_HostingEnvironment.ContentRootPath, subpath.Replace('/', Path.DirectorySeparatorChar), Path.DirectorySeparatorChar.ToString());
                    if (File.Exists(filepath))
                        return new NotFoundFileInfo(filepath);
                }
                return _EmbeddedFileProvider.GetFileInfo(subpath);
            }
