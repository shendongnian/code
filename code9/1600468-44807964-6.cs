    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI _ribbonUI;
        private bool _isPlayButtonVisible = true;
        public bool IsPlayButtonVisible
        {
            get { return this._isPlayButtonVisible; }
            set
            {
                if (this._isPlayButtonVisible != value)
                {
                    this._isPlayButtonVisible = value;
                    this._ribbonUI.InvalidateControl("PlayButton");
                }
            }
        }
    }
