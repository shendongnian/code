     public partial class QuestionsMasterModel
        {
            public QuestionsMasterModel()
            {
            }
            public virtual List<QuestionsModel> QuestionsModelList { get; set; }
        }
         public partial class QuestionsModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
