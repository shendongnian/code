    // ...
 
    using Microsoft.Practices.Prism.ViewModel;
 
    // ...
    public class DynamicControlHelper : NotificationObject
    {
        #region Backing Fields
        private string _text;
        private bool _isEnabled;
        private string _tooltip;
        #endregion Backing Fields
        #region Properties
        
        public string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                if (!string.Equals(this._text, value))
                {
                    this._text = value;
                    this.RaisePropertyChanged(nameof(this.Text));
                }
            }
        }
        public bool IsEnabled
        {
            get
            {
                return this._isEnabled;
            }
            set
            {
                if (this._isEnabled != value)
                {
                    this._isEnabled = value;
                    this.RaisePropertyChanged(nameof(IsEnabled));
                }
            }
        }
        // ...
        public string Tooltip
        {
            get
            {
                return this._tooltip;
            }
            set
            {
                if (!string.Equals(this._tooltip, value))
                {
                    this._tooltip = value;
                    this.RaisePropertyChanged(nameof(this.Tooltip));
                }
            }
        }
        #endregion Properties
    }
