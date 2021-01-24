    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI _ribbonUI;
        public void Invalidate()
        {
            this._ribbonUI.Invalidate();
        }
        public void InvalidatePlayButton()
        {
            this._ribbonUI.Invalidate("PlayButton");
        }
    }
