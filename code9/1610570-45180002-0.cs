    private void MenuItemCallback(object sender, EventArgs e)
            {
                string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
                string title = "ItemContextCommand";
    
                IntPtr hierarchyPointer, selectionContainerPointer;
                Object selectedObject = null;
                IVsMultiItemSelect multiItemSelect;
                uint projectItemId;
    
                IVsMonitorSelection monitorSelection =
                        (IVsMonitorSelection)Package.GetGlobalService(
                        typeof(SVsShellMonitorSelection));
    
                monitorSelection.GetCurrentSelection(out hierarchyPointer,
                                                     out projectItemId,
                                                     out multiItemSelect,
                                                     out selectionContainerPointer);
    
                IVsHierarchy selectedHierarchy = Marshal.GetTypedObjectForIUnknown(
                                                     hierarchyPointer,
                                                     typeof(IVsHierarchy)) as IVsHierarchy;
    
                if (selectedHierarchy != null)
                {
                    ErrorHandler.ThrowOnFailure(selectedHierarchy.GetProperty(
                                                      projectItemId,
                                                      (int)__VSHPROPID.VSHPROPID_ExtObject,
                                                      out selectedObject));
                }
    
                Project selectedProject = selectedObject as Project;
    
                string projectPath = selectedProject.FullName;
    
                // Show a message box to prove we were here
                VsShellUtilities.ShowMessageBox(
                    this.ServiceProvider,
                    message,
                    projectPath,
                    OLEMSGICON.OLEMSGICON_INFO,
                    OLEMSGBUTTON.OLEMSGBUTTON_OK,
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            }
