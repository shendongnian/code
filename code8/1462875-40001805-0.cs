    public ImageTagHelper(
	    IUrlHelperFactory urlHelperFactory,
        IActionContextAccessor actionContextAccesor,)
    {
        this.urlHelperFactory = urlHelperFactory;
        this.actionContextAccesor = actionContextAccesor;
    }
	
    private IUrlHelperFactory urlHelperFactory;
    private IActionContextAccessor actionContextAccesor;
	public override void Process(TagHelperContext context, TagHelperOutput output)
    {
	    var urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccesor.ActionContext);
		var myUrl = urlHelper.Content("~/somefilebelowwwwroot");
		...
	}
    
