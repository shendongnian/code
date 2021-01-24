    private new Dictionary<string, string> AttachmentNames
    {
        get
        {
            /* may want to lock if multi threads is a possibility */
            if (Session["AttachmentNames"] == null)
                Session["AttachmentNames"] = new Dictionary<string, string>();
                
            return (Dictionary<string, string>) Session["AttachmentNames"];
        }
    }
