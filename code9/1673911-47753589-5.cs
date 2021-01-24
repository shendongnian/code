    protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
    {
        DateTime sDate = Calendar1.SelectedDate;
        string doc = ddlDoctor.SelectedValue.ToString();
        GenerateDocSlotLabels(doc, sDate);
    } 
...
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           DateTime sDate = Calendar1.SelectedDate;
           string doc = ddlDoctor.SelectedValue.ToString();
           GenerateDocSlotLabels(doc, sDate);
        }
    } 
