    private int ReqState
    {
        get
        {
            return (this.HttpContext.Session["ReqState"] as int?).GetValueOrDefault(-1);
        }
        set
        {
            this.HttpContext.Session["ReqState"] = value;
        }
    }
