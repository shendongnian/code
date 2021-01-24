        EnvDTE.TextPoint p = GetCursorTextPoint(DTE);
        foreach (EnvDTE.vsCMElement i in Enum.GetValues(typeof(EnvDTE.vsCMElement)))
        {
            EnvDTE.CodeElement e = p.CodeElement[i];
            if (e != null)
                System.Windows.MessageBox.Show(i.ToString() + " " + e.FullName);
        }
