        internal static dynamic CurrentSlide
        {
            get
            {
                if (Globals.ThisAddIn.Application.Active == MsoTriState.msoTrue &&
                    Globals.ThisAddIn.Application.ActiveWindow.Panes[2].Active == MsoTriState.msoTrue)
                {
                    return Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
                }
                return null;
            }
        }
