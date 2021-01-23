    namespace CascadingDDL
    {
        using System;
        using System.Web.UI;
    
        public partial class _Default : Page
        {
            public const int StatusRejected = 2;
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!this.IsPostBack)
                {
                    this.cboComments.Enabled = false;
                }
            }
    
            protected void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
            {
                var status = int.Parse(this.cboStatus.SelectedValue);
                if (status == StatusRejected)
                {
                    this.cboComments.Enabled = true;
                }
                else
                {
                    this.cboComments.Enabled = false;
                }
            }
        }
    }
