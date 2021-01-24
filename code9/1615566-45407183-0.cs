    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using EnvDTE;
    using Microsoft.VisualStudio.ComponentModelHost;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.TemplateWizard;
    using NuGet.VisualStudio;
    using Task = System.Threading.Tasks.Task;
    
    namespace Example
    {
        public class NuGetTemplateWizard : IWizard
        {
            List<string> _packages;
    
            public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
            {
                if (customParams.Length > 0) {
                    var vstemplate = XDocument.Load((string)customParams[0]);
                    _packages = vstemplate.Root
                        .ElementsNoNamespace("WizardData")
                        .ElementsNoNamespace("packages")
                        .ElementsNoNamespace("package")
                        .Select(pkg => pkg.Attribute("id").Value)
                        .ToList();
                }
            }
    
            public void ProjectFinishedGenerating(Project project)
            {
                Task.Run(delegate {
                    var componentModel = (IComponentModel)Package.GetGlobalService(typeof(SComponentModel));
                    var _installer = componentModel.GetService<IVsPackageInstaller2>();
    
                    foreach (var package in _packages) {
                        _installer.InstallLatestPackage(null, project, package, false, false);
                    }
                });
            }
    
            public bool ShouldAddProjectItem(string filePath) { return true; }
            public void BeforeOpeningFile(ProjectItem projectItem) { }
            public void ProjectItemFinishedGenerating(ProjectItem projectItem) { }
            public void RunFinished() { }
        }
    }
