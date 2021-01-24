                if (name != null)
                {
                    var rm = new ResourceManager(name, resourceAssembly);
                    var rs = rm.GetResourceSet(Thread.CurrentThread.CurrentUICulture, true, true);
                    _form.Localize(rs.GetEnumerator(), out missing, out extra);
                    if (missing.Any())
                    {
                        throw new MissingManifestResourceException($"Missing resources {missing}");
                    }
                }
