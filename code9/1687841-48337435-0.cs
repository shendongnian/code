     Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var item in assemblies)
                {
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(item.Location);
                }
