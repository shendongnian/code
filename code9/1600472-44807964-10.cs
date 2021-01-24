    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI _ribbonUI;
        private bool _isPlayButtonVisible = true;
        // here's a property that makes it easy to update the visibility of the play button
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
        // here's the callback that Excel will call
        public bool GetIsPlayButtonVisible(IRibbonControl control)
        {
            return this.IsPlayButtonVisible
        }
    }
