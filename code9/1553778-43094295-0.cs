            var query = new SetupConfiguration();
            var query2 = (ISetupConfiguration2)query;
            var e = query2.EnumAllInstances();
            var helper = (ISetupHelper)query;
            int fetched;
            var instances = new ISetupInstance[1];
            do
            {
                e.Next(1, instances, out fetched);
                if (fetched > 0)
                {
                    var instance = instances[0];
                    var instance2 = (ISetupInstance2)instance;
                    var state = instance2.GetState();
                    // Skip non-complete instance, I guess?
                    // Skip non-local instance, I guess?
                    // Skip unregistered products?
                    if (state != InstanceState.Complete
                        || (state & InstanceState.Local) != InstanceState.Local
                        || (state & InstanceState.Registered) != InstanceState.Registered)
                    {
                        continue;
                    }
                    var msBuildComponent =
                        instance2.GetPackages()
                            .FirstOrDefault(
                                p =>
                                    p.GetId()
                                        .Equals("Microsoft.Component.MSBuild",
                                            StringComparison.InvariantCultureIgnoreCase));
                    if (msBuildComponent == null)
                    {
                        continue;
                    }
                    var instanceRootDirectory = instance2.GetInstallationPath();
                    var msbuildPathInInstance = Path.Combine(instanceRootDirectory, "MSBuild", msBuildVersion, "Bin", "msbuild.exe");
                    if (File.Exists(msbuildPathInInstance))
                    {
                        return msbuildPathInInstance;
                    }
                }
            } while (fetched > 0);
