    public class Quiz
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
    
    public partial class WebForm2 : System.Web.UI.Page
    {
        // This could come from database
        private IList<Quiz> Quizzes
        {
            get
            {
                return new List<Quiz>
                {
                    new Quiz {Id = 1, Question = "Question 1"},
                    new Quiz {Id = 2, Question = "Question 2"},
                    new Quiz {Id = 3, Question = "Question 3"},
                    new Quiz {Id = 4, Question = "Question 4"},
                    new Quiz {Id = 5, Question = "Question 5"}
                };
            }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListView1.DataSource = Quizzes;
                ListView1.DataBind();
            }
        }
    
        protected void Submit_Click(object sender, EventArgs e)
        {
            IList<Quiz> quizzes = new List<Quiz>();
            for (int i = 0, length = Quizzes.Count; i < length; i++)
            {
                ListViewDataItem item = ListView1.Items[i];
                var radioButtonList = item.FindControl("AnswerRadioButtonList") as RadioButtonList;
                var idHiddenField = item.FindControl("IdHiddenField") as HiddenField;
                quizzes.Add(new Quiz
                {
                    Id = Convert.ToInt32(idHiddenField.Value),
                    Answer = radioButtonList.SelectedValue
                });
            }
        }
    }
