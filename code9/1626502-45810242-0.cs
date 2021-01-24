        EnvDTE80.DTE2 s_dte;
        EnvDTE.FindEvents s_findEvents;
        public const string vsWindowKindFindResults1 = "{0F887920-C2B6-11D2-9375-0080C747D9A0}";
        public frmFindHelper()
        {
            InitializeComponent();
            s_dte = (EnvDTE80.DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE");
            s_dte.MainWindow.Activate();
            s_findEvents = s_dte.Events.FindEvents;
            s_findEvents.FindDone += new EnvDTE._dispFindEvents_FindDoneEventHandler(OnFindDone);
        }
        private void OnFindDone(EnvDTE.vsFindResult result, bool cancelled)
        {
            if (result == EnvDTE.vsFindResult.vsFindResultFound)
            {
                var findWindow = s_dte.Windows.Item(vsWindowKindFindResults1);
                string data = "";
                var selection = findWindow.Selection as EnvDTE.TextSelection;
                selection.SelectAll();
                data = selection.Text;
                MessageBox.Show("Done!");
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            EnvDTE.Find find = s_dte.Find;
            find.Action = EnvDTE.vsFindAction.vsFindActionFindAll;
            find.FindWhat = txtSearch.Text;
            find.MatchWholeWord = false;
            find.ResultsLocation = EnvDTE.vsFindResultsLocation.vsFindResults1;
            find.Target = EnvDTE.vsFindTarget.vsFindTargetSolution;
            find.PatternSyntax = EnvDTE.vsFindPatternSyntax.vsFindPatternSyntaxRegExpr;
            find.SearchSubfolders = true;
            var x = s_dte.Find.FindWhat;
            EnvDTE.vsFindResult result = find.Execute();
        }
