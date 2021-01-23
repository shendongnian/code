    public partial class frmBenefitSummaryList : System.Web.UI.Page
    {
        public string PlanID;
        public string AuditID;
        protected void Page_Load(object sender, EventArgs e)
        {
            PlanID = Request["PlanID"];
            AuditID = Request["AuditID"];
            this.MaintainScrollPositionOnPostBack = true;
            BindAccordions();
            if (!Page.IsPostBack)
            {
                LoadIssues();
                LoadResolutions();
                LoadNetworks();
                LoadStatus();
            }
        }
