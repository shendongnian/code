    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NuGet;
    using Shouldly;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    namespace UnitTests
    {
        [TestClass]
        public class NugetConsolidationTest
        {
            private List<string> _ignoredPackages = new List<string>();
            [TestMethod]
            public void AllNugetPackagesAreConsolidated()
            {
                var packageVersionMapping = new Dictionary<string, List<string>>();
            
                var parentDir = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent).Parent.FullName;
                var files = Directory.GetFiles(parentDir, "packages.config", SearchOption.AllDirectories);
                foreach (var packageFile in files)
                {
                    var file = new PackageReferenceFile(packageFile);
                    var refs = file.GetPackageReferences(true);
                    foreach (var packageRef in refs)
                    {
                        if (_ignoredPackages.Contains(packageRef.Id))
                            continue;
                        if (!packageVersionMapping.ContainsKey(packageRef.Id))
                            packageVersionMapping[packageRef.Id] = new List<string>() { packageRef.Version.ToFullString() };
                        else
                        {
                            if (packageVersionMapping[packageRef.Id].All(x => !x.Equals(packageRef.Version.ToFullString(),
                                    StringComparison.InvariantCultureIgnoreCase)))
                                packageVersionMapping[packageRef.Id].Add(packageRef.Version.ToFullString());
                        }
                    }
                }
                var errors = packageVersionMapping.Where(x => x.Value.Count > 1)?.
                    Select(x => $"Package {x.Key} has {x.Value.Count} separate versions installed! Current versions are {string.Join(", ", x.Value)}");
                errors.ShouldBeEmpty();
            }
        }
    }
