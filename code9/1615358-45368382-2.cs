    public class YourClass : NotificationObject
    {
        private bool _checkBoxValue;
        public bool CheckboxValue
        {
            get
            {
                return this._checkBoxValue;
            }
            set
            {
                if (this._checkBoxValue!= value)
                {
                    this._checkBoxValue= value;
                    this.RaisePropertyChanged(nameof(this.CheckboxValue));
                }
            }
        }
    }
