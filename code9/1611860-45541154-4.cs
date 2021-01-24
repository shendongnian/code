    public partial class Account : MyBaseEntity
    {
        ...
        public Microsoft.Xrm.Sdk.OptionSetValue AccountRatingCode
        {
		    get
		    {
			    return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("accountratingcode");
		    }
		    set
		    {
			    this.SetAttributeValue("accountratingcode", value);
		    }
	    }
        ...
    }
