    protected void Page_Load(object sender, EventArgs e)
    {    
        locationsTable.InnerHtml = htmlString;
        htmlString += "<td><button id=\"clicker\">Add License</a></td>";
        if(IsPostBack){
            var eventTarget = Request.Params["__EVENTTARGET"]
            var buttonClicked = eventTarget.Substring(eventTarget.LastIndexOf("$") + 1).Equals("clicker")
        }
    }
