    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace STACK_OVERFLOW
    {
        public partial class Form1 : System.Web.UI.Page
        {
        GridView gvEmployee = new GridView();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            BindData(table);
        }
        protected void BindData(DataTable dt)
        {
            gvEmployee.AllowPaging = true;
            gvEmployee.PageSize = 2;
            gvEmployee.AutoGenerateColumns = false;
            gvEmployee.PageIndexChanging += gvEmployee_PageIndexChanging;
            if (dt != null)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    BoundField boundfield = new BoundField();
                    boundfield.DataField = dt.Columns[i].ColumnName.ToString();
                    boundfield.HeaderText = dt.Columns[i].ColumnName.ToString();
                    gvEmployee.Columns.Add(boundfield);
                }
                Panel1.Controls.Add(gvEmployee);
                gvEmployee.DataSource = dt;
                gvEmployee.DataBind();
                gvEmployee.Width = 600;
                gvEmployee.HeaderStyle.CssClass = "header";
                gvEmployee.RowStyle.CssClass = "rowstyle";
            }
        }
        void gvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployee.PageIndex = e.NewPageIndex;
            gvEmployee.DataBind();
        }
        
    }
    }
