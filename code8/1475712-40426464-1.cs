    public class Question
    {
        public int QuestionID { get; set; }
        public string KeyObjective { get; set; }
    }
    
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = new List<Question>
                {
                    new Question {QuestionID = 1, KeyObjective = "One"},
                    new Question {QuestionID = 2, KeyObjective = "Two"},
                    new Question {QuestionID = 3, KeyObjective = "Three"},
                };
                GridView1.DataBind();
            }
        }
    
        protected void GridView1_OnPreRender(object sender, EventArgs e)
        {
            bool isEditor = true; // Business logic here
            if (isEditor)
            {
                // Enter correct column index.
                GridView1.Columns[2].Visible = false;
            }
        }
    }
