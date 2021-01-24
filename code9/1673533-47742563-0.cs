    update.aspx.cs  
    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    using (datademoEntities db = new datademoEntities())
                    {
                        var query = from tbl in db.demotables select new{tbl.Id, tbl.FirstName, tbl.gender, tbl.PhoneNumber, tbl.Role};
                        ddlupdate.DataSource = query.ToList();
                        ddlupdate.DataTextField = "FirstName";
                        ddlupdate.DataValueField = "id";
                        ddlupdate.DataBind();
                        ddlupdate.Items.Insert(0, new ListItem("select"));
    
                    } }
                 
                    
                }
           static int did;
            protected void ddlupdate_SelectedIndexChanged(object sender, 
        EventArgs e)
              {
                did = int.Parse(ddlupdate.SelectedValue);
                using (datademoEntities db = new datademoEntities())
                {
                    var query = (from tbl in db.demotables
                                 where tbl.Id == did
                                 select tbl).First();
                    txtname.Text = query.FirstName;
                    rbgender.DataTextField = query.gender;
    
                    txtphone.Text = query.PhoneNumber.ToString();
    
                }
            }
           
            protected void btnupdate_Click(object sender, EventArgs e)
            {
                string dname = txtname.Text;
                int dphone = int.Parse(txtphone.Text);
                using (datademoEntities db = new datademoEntities())
                {
                    demotable tbl = (from row in db.demotables
                                     where
                                     row.Id==did
                                     select row).First();
    
    
                     tbl.FirstName = dname;
                    tbl.PhoneNumber = dphone;
                    db.SaveChanges();
                    Response.AddHeader("Refresh", "3;url.display.aspx");
                                     }
                
    
    
            }
        }
        }
    display.aspx.cs
      public partial class display : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                datademoEntities db = new datademoEntities();
                var query = (from tbl in db.demotables select tbl).ToList();
                GridView1.DataSource = query;
                GridView1.DataBind();
                
            }
        }
    }
    
    INSERT.apx.cs
     protected void btnsubmit_Click(object sender, EventArgs e)
            {
                datademoEntities dm = new datademoEntities();
                string dname = txtname.Text;
                string drole = ddlrole.SelectedValue;
                string dphone = txtphone.Text;
                string dgender = rbgender.SelectedValue;
                demotable tbl = new demotable();
                tbl.FirstName = dname;
                tbl.Role = drole;
                tbl.PhoneNumber = Convert.ToInt32(dphone);
                tbl.gender = dgender;
                dm.demotables.Add(tbl);
                   dm.SaveChanges();
