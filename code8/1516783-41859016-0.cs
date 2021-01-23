    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Xml.Linq;
    using System.IO;
    using System.Data.SqlClient;
    using System.Text;
    public partial class MenuControl : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
          Menu1.MenuItemClick += new MenuEventHandler(Menu1_MenuItemClick);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateMenu(this.GetData(), 0, null);
            }
        }
        public DataTable GetData(int parentMenuId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("MenuID", typeof(int)));
            dt.Columns.Add(new DataColumn("MenuName", typeof(string)));
            dt.Columns.Add(new DataColumn("MenuLocation", typeof(string)));
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var menu = db.Menus.Where(m => m.ParentMenuID.Equals(parentMenuId) && m.IsActive.Equals(true)).Select(m => new { MenuID = m.MenuID, MenuTitle = m.MenuName, MenulLocation = m.MenuLocation }).ToList();
                foreach (var menuItem in menu)
                {
                    if (menuItem != null)
                    {
                        DataRow dr = dt.NewRow();
                        dr["MenuID"] = menuItem.MenuID;
                        dr["MenuName"] = menuItem.MenuTitle.ToString();
                        dr["MenuLocation"] = menuItem.MenulLocation.ToString();
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }
        public void PopulateMenu(DataTable dt, int parentMenuId, MenuItem parentMenuItem)
        {
            string currentPage = Path.GetFileName(Request.Url.AbsolutePath);
            foreach (DataRow row in dt.Rows)
            {
                MenuItem menuItem = new MenuItem { Value = row["MenuID"].ToString(), Text = row["MenuName"].ToString(), NavigateUrl = row["MenuLocation"].ToString(), Selected = row["MenuLocation"].ToString().EndsWith(currentPage, StringComparison.CurrentCultureIgnoreCase) };
                if (parentMenuId == 0)
                {
                    Menu1.Items.Add(menuItem);
                    DataTable dtChild = this.GetData(int.Parse(menuItem.Value));
                    PopulateMenu(dtChild, int.Parse(menuItem.Value), menuItem);
                }
                else
                {
                    parentMenuItem.ChildItems.Add(menuItem);
                }
            }
        }
        public DataTable GetData()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                DataTable dt = new DataTable("Menu");
                dt.Columns.Add(new DataColumn("MenuID", typeof(int)));
                dt.Columns.Add(new DataColumn("MenuName", typeof(string)));
                dt.Columns.Add(new DataColumn("MenuLocation", typeof(string)));
                dt.Columns.Add(new DataColumn("ParentMenuID", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["MenuID"] = "1";
                dr["MenuName"] = "Home";
                dr["MenuLocation"] = "~/User_Landing_Page.aspx";
                dt.Rows.Add(dr);
                foreach (var item in db.Menus.Where(m => m.IsActive.Equals(true) && m.type_id.Equals(int.Parse(Session["TypeID"].ToString())) && m.ParentMenuID == null).Select(m => new
                {
                    MenuID = m.MenuID,
                    MenuName = m.MenuName,
                    MenuLocation = m.MenuLocation,
                    ParentMenuID = m.ParentMenuID
                }).ToList())
                {
                    if (item != null)
                    {
                        DataRow dr1 = dt.NewRow();
                        dr1["MenuID"] = int.Parse(item.MenuID.ToString());
                        dr1["MenuName"] = item.MenuName.ToString();
                        if (item.MenuLocation != null)
                        {
                            dr1["MenuLocation"] = item.MenuLocation.ToString();
                        }
                        if (item.ParentMenuID != null)
                        {
                            dr1["ParentMenuID"] = int.Parse(item.ParentMenuID.ToString());
                        }
                        else
                        {
                            dr1["ParentMenuID"] = 0;
                        }
                        dt.Rows.Add(dr1);
                    }
                }
                return dt;
            }
        }
    
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (e.Item.Selected.ToString())
            {
                case "Compose Mail":
                    Session["flag"] = "1";
                    Response.Redirect(e.CommandArgument.ToString());
                    break;
                case "From User Master":
                    Session["flag"] = "2";
                    Response.Redirect(e.CommandArgument.ToString());
                    break;
                case "Subscriber Master":
                    Session["flag"] = "3";
                    Response.Redirect(e.CommandArgument.ToString());
                    break;
                case "Import Susbcribers":
                    Session["flag"] = "4";
                    Response.Redirect(e.CommandArgument.ToString());
                    break;
                default:
                    Session["flag"] = "0";
                    Response.Redirect(e.CommandArgument.ToString());
                    break;
            }
        }
    }
