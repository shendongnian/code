    private IEnumerable<SelectListItem> _targetList
 
    public IEnumerable<SelectListItem> TargetList
    {
        get
        {
            return _targetList;
        }
        private set
        {
            _targetList = new List<SelectListItem> { new SelectListItem { Value = "Android", Text = "Android" },
                                                    new SelectListItem { Value= "WebGL", Text="WebGL" },
                                                    new SelectListItem { Value= "Windows", Text="Windows" },
                                                    new SelectListItem { Value= "IOS", Text="IOS" }};
        }
    }
