    internal sealed class TemplateCommand
    {
        private const int CustomCommandId = 0x1023;
        private static readonly Guid CommandSet = COMMANDSET_GUID;
        private readonly Package _package;
        // ReSharper disable MemberCanBePrivate.Global
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        public IServiceProvider ServiceProvider => _package;
        public static TemplateCommand Instance { get; set; }
        // ReSharper restore UnusedAutoPropertyAccessor.Global
        // ReSharper restore MemberCanBePrivate.Global
        public static void Initialize(Package package)
        {
            Instance = new TemplateCommand(package);
        }
        private TemplateCommand(Package package)
        {
            if (package == null)
                throw new ArgumentNullException(nameof(package));
            _package = package;
            var commandService = ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService == null)
                return;
            
            AddCommand(commandService, CustomCommandId, CreateCustomCommand);
        }
        private static void AddCommand(IMenuCommandService commandService, int commandId, EventHandler callback)
        {
            var command = new CommandID(CommandSet, commandId);
            var menuItem = new MenuCommand(callback, command);
            commandService.AddCommand(menuItem);
        }
        private void CreateCustomCommand(object sender, EventArgs eventArgs)
        {
            AddNewItem("MyCustomCommand");
        }
        private void AddNewItem(string itemName)
        {
            var dte = ServiceProvider.GetService(typeof(DTE)) as DTE;
            if (dte == null)
                return;
            int iDontShowAgain;
            uint projectItemId;
            var strFilter = string.Empty;
            var hierarchy = GetCurrentVsHierarchySelection(out projectItemId);
            if (hierarchy == null)
                return;
            var project = ToDteProject(hierarchy);
            if (project == null)
                return;
            var vsProject = ToVsProject(project);
            if (vsProject == null)
                return;
            var addItemDialog = ServiceProvider.GetService(typeof(IVsAddProjectItemDlg)) as IVsAddProjectItemDlg;
            if (addItemDialog == null)
                return;
            const uint uiFlags = (uint)(__VSADDITEMFLAGS.VSADDITEM_AddNewItems | __VSADDITEMFLAGS.VSADDITEM_SuggestTemplateName | __VSADDITEMFLAGS.VSADDITEM_AllowHiddenTreeView);
            const string categoryNameInNewFileDialog = "MyCustomTemplates";
            // ProjectGuid for C# projects
            var projGuid = new Guid("FAE04EC0-301F-11D3-BF4B-00C04F79EFBC");
            string projectDirectoryPath;
            hierarchy.GetCanonicalName(projectItemId, out projectDirectoryPath);
            var itemNameInNewFileDialog = itemName;
            addItemDialog.AddProjectItemDlg(projectItemId,
                                            ref projGuid,
                                            vsProject,
                                            uiFlags,
                                            categoryNameInNewFileDialog,
                                            itemNameInNewFileDialog,
                                            ref projectDirectoryPath,
                                            ref strFilter,
                                            out iDontShowAgain);
        }
        private static IVsHierarchy GetCurrentVsHierarchySelection(out uint projectItemId)
        {
            IntPtr hierarchyPtr, selectionContainerPtr;
            IVsMultiItemSelect mis;
            var monitorSelection = (IVsMonitorSelection)Package.GetGlobalService(typeof(SVsShellMonitorSelection));
            monitorSelection.GetCurrentSelection(out hierarchyPtr, out projectItemId, out mis, out selectionContainerPtr);
            var hierarchy = Marshal.GetTypedObjectForIUnknown(hierarchyPtr, typeof(IVsHierarchy)) as IVsHierarchy;
            return hierarchy;
        }
        private static Project ToDteProject(IVsHierarchy hierarchy)
        {
            if (hierarchy == null)
                throw new ArgumentNullException(nameof(hierarchy));
            object prjObject;
            if (hierarchy.GetProperty(0xfffffffe, (int)__VSHPROPID.VSHPROPID_ExtObject, out prjObject) == VSConstants.S_OK)
                return (Project)prjObject;
            throw new ArgumentException("Hierarchy is not a project.");
        }
        private IVsProject ToVsProject(Project project)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project));
            var vsSln = ServiceProvider.GetService(typeof(IVsSolution)) as IVsSolution;
            if (vsSln == null)
                throw new ArgumentException("Project is not a VS project.");
            IVsHierarchy vsHierarchy;
            vsSln.GetProjectOfUniqueName(project.UniqueName, out vsHierarchy);
            // ReSharper disable SuspiciousTypeConversion.Global
            var vsProject = vsHierarchy as IVsProject;
            // ReSharper restore SuspiciousTypeConversion.Global
            if (vsProject != null)
                return vsProject;
            throw new ArgumentException("Project is not a VS project.");
        }
    }
