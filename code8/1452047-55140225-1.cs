    public partial class Employeedetail : System.Web.UI.Page {
        // SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());
        protected void Page_Load(object sender, EventArgs e) {
            string strEid = Request.QueryString["EId"];
            DisplayEmployeeDetail(strEid);
        }
        public DataTable DisplayEmployeeDetail(string strEid) {           
            DAL.EMPDA db = new DAL.EMPDA();
            EMPBOL objEMPBOL = new EMPBOL();
            objEMPBOL.e_id = strEid;
            DataTable dt = db.EmpDetail(objEMPBOL);
            Txtcode.Text = dt.Rows[0]["emp_Code"].ToString();
            TxtFName.Text = dt.Rows[0]["emp_firstname"].ToString();
            TxtLName.Text = dt.Rows[0]["emp_lastname"].ToString();
            TxtDesig.Text = dt.Rows[0]["emp_designation"].ToString();
            Txtbirthdate.Text = dt.Rows[0]["emp_dob"].ToString();
            TxtQualification.Text = dt.Rows[0]["emp_qualification"].ToString();
            Txtempcity.Text = dt.Rows[0]["emp_city"].ToString();
            Txtemailid.Text = dt.Rows[0]["emp_email"].ToString();
            Txtphonenumber.Text = dt.Rows[0]["emp_phone"].ToString();
            Txtsalry.Text = dt.Rows[0]["emp_salary"].ToString();
            return dt;           
        }
    }
