    public class C : VisualCommanderExt.ICommand
    {
        public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package)
        {
            string propertyName = Microsoft.VisualBasic.Interaction.InputBox("Property name", "Create view model property [1/2]", "Foo", -1, -1);
            string propertyType = Microsoft.VisualBasic.Interaction.InputBox("Property type", "Create view model property [2/2]", "double", -1, -1);
            string fieldName = "_" + System.Char.ToLower(propertyName[0]) + propertyName.Substring(1);
            string snippet = @"
    private {1} {2};
    public {1} {0}
    {{
       get {{ return {2}; }}
       set {{ SetProperty(ref {2}, value); }}
    }}
    ";
            EnvDTE.TextSelection ts = DTE.ActiveDocument.Selection as EnvDTE.TextSelection;
            ts.Text = string.Format(snippet, propertyName, propertyType, fieldName);
        }
    }
