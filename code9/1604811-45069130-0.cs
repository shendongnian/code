    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace List
    {
        public class ListUsers
        {
            public List<Data.Area> AreaList()
            {
                var list = new List<Data.Area>();
                Data.Area area1 = new Data.Area { AREA = "ENG", STANDBY = 0, TEAM = "team1" };
                Data.Area area2 = new Data.Area { AREA = "ENG", STANDBY = 0, TEAM = "team2" };
                Data.Area area3 = new Data.Area { AREA = "area3", STANDBY = 3, TEAM = "team3" };
                list.Add(area1);
                list.Add(area2);
                list.Add(area3);
                return list;
            }
        }
    }
    namespace Data
    {
        public class Area
        {
            public string AREA { get; set; }
            public int STANDBY { get; set; }
            public string TEAM { get; set; }
        }
    }
    namespace WebApplication1
    {
        public partial class Dashboard : System.Web.UI.Page
        {
            //BTW static variable are shared across multiple users of your web site
            static bool enable = false;
            override protected void OnInit(EventArgs e)
            {
                //NEED TO set event listener in oninit everytime
                DynamicButton();
            }
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    //DynamicButton();
                }
                else if (enable)
                {
                    //DynamicButton();
                }
            }
            protected void DynamicButton()
            {
                List.ListUsers listArea = new List.ListUsers();
                List<Data.Area> Area = listArea.AreaList();
                List<Data.Area> ListOfEquiposOk = Area.Where(x => x.AREA == "ENG" && x.STANDBY == 0).ToList();
                var TeamFCH = ListOfEquiposOk.Select(x => x.TEAM).Distinct().ToList();
                foreach (var team in TeamFCH)
                {
                    LinkButton newButton = new LinkButton();
                    newButton.CommandName = "Btn" + Convert.ToString(team);
                    newButton.ID = "Btn_" + Convert.ToString(team);
                    newButton.Text = team;
                    newButton.CommandArgument = "ENG";
                    newButton.Click += new EventHandler(newButton_Click);
                    pan1.Controls.Add(newButton);
                    newButton.CssClass = "btn-primary outline separate";
                }
            }
            public void newButton_Click(object sender, EventArgs e)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ModalGood();", true);
                List.ListUsers listArea = new List.ListUsers();
                List<Data.Area> Area = listArea.AreaList();
                List<Data.Area> ListOfToolsOk = Area.Where(x => x.AREA == "ENG" && x.TEAM == "516" && x.STANDBY == 0).ToList();
                var ToolArea = ListOfToolsOk.Select(x => x.TEAM);
                Grv_Eng.DataSource = ListOfToolsOk;
                Grv_Eng.DataBind();
            }
            protected void DButton(object sender, EventArgs e)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showAndHide();", true);
                enable = true;
                DynamicButton();
            }
        }
    }
