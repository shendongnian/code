        private void MenuItemCallback(object sender, EventArgs e)
        {
            EnvDTE.DTE dte = (EnvDTE.DTE)this.ServiceProvider.GetService(typeof(EnvDTE.DTE));
            EnvDTE.TextSelection ts = dte.ActiveWindow.Selection as EnvDTE.TextSelection;
            if (ts == null)
                return;
            EnvDTE.CodeFunction func = ts.ActivePoint.CodeElement[vsCMElement.vsCMElementFunction]
                        as EnvDTE.CodeFunction;
            if (func == null)
                return;
            string message = dte.ActiveWindow.Document.FullName + System.Environment.NewLine +
              "Line " + ts.CurrentLine + System.Environment.NewLine +
              func.FullName;
            string title = "GetLineNo";
            VsShellUtilities.ShowMessageBox(
                this.ServiceProvider,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }
