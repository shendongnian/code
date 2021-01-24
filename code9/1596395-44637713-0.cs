    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    
    namespace DropdownClicks
    {
    
        public partial class WebForm1 : System.Web.UI.Page
        {
            static List<string> itemsToInsert = new List<string> { "first", "second", "third" };
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!this.IsPostBack)
                {
                    //only do this binding on page load, otherwise you'll "reset" the grid every time there is a postBack.
                    mydg.DataSource = itemsToInsert;
                    mydg.DataBind();
                }
            }
    
            protected void Unnamed_Click(object sender, EventArgs e)
            {
                DropDownList DDLP;
                string acceptStatus;
                string retVal = "";
                for (int i = 0; i < mydg.Items.Count; i++)
                {
                    DDLP = (DropDownList)mydg.Items[i].FindControl("ddlApprovalStatus");
                    acceptStatus = DDLP.SelectedValue;
                    retVal += acceptStatus + ", ";
                }
                lbl_1.Text = retVal;
            }
        }
    }
