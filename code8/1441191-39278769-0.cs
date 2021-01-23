    public abstract class BaseAnswerViewModel
    {
        public abstract string QuestionText { get; set; }
        public string AnswerText { get; set; }
    }
    public class DateTimeAnswerViewModel : BaseAnswerViewModel
    {
        [DataType(DataType.DateTime)]
        public override string QuestionText { get; set; }
    }
    public class PasswordAnswerViewModel : BaseAnswerViewModel
    {
        [DataType(DataType.Password)]
        public override string QuestionText { get; set; }
    }
