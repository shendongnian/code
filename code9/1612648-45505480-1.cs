    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
        public partial class Test : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("LabelComentarios");
                    dt.Columns.Add("PostId");
                    dt.Rows.Add("esresrer");
                    dt.Rows.Add("esresrer");
                    dt.Rows.Add("esresrer");
    
    
                    Posts.DataSource = dt;
                    Posts.DataBind();
                }
            }
            protected void Posts_OnItemCreated(object sender, RepeaterItemEventArgs e)
            {
                var control = e.Item.FindControl("Button1");
                ScriptManager.GetCurrent(Page).RegisterAsyncPostBackControl(control);
            }
            protected void btnComentar_OnCommand(object sender, CommandEventArgs e)
            {
                //MyCode();
                foreach (RepeaterItem item in Posts.Items)
                {
    
    
                    var lbl = (Label)item.FindControl("Label1");
                    lbl.Text = "testest";
                    var panel = (UpdatePanel)item.FindControl("UpdatePanel1");
                    panel.Update();
                }
            }
        }
    }
