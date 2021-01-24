    public partial class Account : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {
        ...
        public Microsoft.Xrm.Sdk.OptionSetValue AccountRatingCode
    	{
    		[System.Diagnostics.DebuggerNonUserCode()]
    		get
    		{
    			return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("accountratingcode");
    		}
    		[System.Diagnostics.DebuggerNonUserCode()]
    		set
    		{
    			this.OnPropertyChanging("AccountRatingCode");
    			this.SetAttributeValue("accountratingcode", value);
    			this.OnPropertyChanged("AccountRatingCode");
    		}
    	}
        ...
    }
	
