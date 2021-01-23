    public interface IExam<out T> where T:IQuestion {
      int Id { get; set; }
      string Description { set; get; }
      IEnumerable<T> GetQuestions();
    }
    public interface IQuestion{
	  int Id { get; set; }
	  string Description { set; get; }
      IExam<IQuestion> Exam { get; }
    }
    public class SingleQuestion:IQuestion {
      public string Description { get; set; }
      public int Id { get; set; }
      IExam<IQuestion> IQuestion.Exam {
        get { return Exam; }
      }
      public SingleExam Exam { get; set; }
    }
    public class SingleExam:IExam<SingleQuestion> {
      public int Id { get; set; }
      public string Description { get; set; }
      private IEnumerable<SingleQuestion> _questions;
      public IEnumerable<SingleQuestion> GetQuestions() {
        return _questions;
      }
      public void SetQuestions(IEnumerable<SingleQuestion> questions) {
        _questions = questions;
      }
    }
