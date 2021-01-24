    public class C : VisualCommanderExt.ICommand
    {
        public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package)
        {
            this.DTE = DTE;
    
            EnvDTE.CodeVariable v = FindCurrentVariable();
            if (v != null)
            {
                string initialization = v.Name + " = GetComponent<" + v.Type.CodeType.Name + ">();";
                AddLine(FindFunction("Start"), initialization);
            }
        }
    
        EnvDTE.CodeFunction FindFunction(string name)
        {
            EnvDTE.TextSelection ts = DTE.ActiveWindow.Selection as EnvDTE.TextSelection;
            if (ts == null)
                return null;
            EnvDTE.CodeClass codeClass = ts.ActivePoint.CodeElement[EnvDTE.vsCMElement.vsCMElementClass]
                as EnvDTE.CodeClass;
            if (codeClass == null)
                return null;
            foreach (EnvDTE.CodeElement elem in codeClass.Members)
            {
                if (elem.Kind == EnvDTE.vsCMElement.vsCMElementFunction && elem.Name == name)
                    return elem as EnvDTE.CodeFunction;
            }
            return null;
        }
    
        EnvDTE.CodeVariable FindCurrentVariable()
        {
            EnvDTE.TextSelection ts = DTE.ActiveWindow.Selection as EnvDTE.TextSelection;
            if (ts == null)
                return null;
            return ts.ActivePoint.CodeElement[EnvDTE.vsCMElement.vsCMElementVariable]
                as EnvDTE.CodeVariable;
        }
    
        void AddLine(EnvDTE.CodeFunction f, string text)
        {
            EnvDTE.TextPoint tp = f.GetStartPoint(EnvDTE.vsCMPart.vsCMPartBody);
            EnvDTE.EditPoint p = tp.CreateEditPoint();
            p.Insert(text + System.Environment.NewLine);
            p.SmartFormat(tp);
        }
    
        EnvDTE80.DTE2 DTE;
    }
