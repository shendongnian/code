    public class QuestionAndAnswers
    {
        public QuestionAndAnswers()
        {
           Answers = new List<Answer>();
        }
        public int Number { get; set; }
        public string Question { get; set; }
        public List<Answer> Answers { get; set; }
    }
<!---->
    <local:QuestionnaireControl>
      <local:QuestionnaireControl.Questions>
        <local:QuestionAndAnswers Number="1" Question="Is this working?">
          <local:QuestionAndAnswers.Answers>
           <local:Answer Value="0" Text="Yes" />
           <local:Answer Value="1" Text="No" IsSelected="true"/>
           <local:Answer Value="2" Text="Help Me Please" />
          </local:QuestionAndAnswers.Answers>
        </local:QuestionAndAnswers>
        <local:QuestionAndAnswers Number="2" Question="Are these questions sharing answers?">
          <local:QuestionAndAnswers.Answers>
           <local:Answer Value="0" Text="Yes" IsSelected="true"/>
           <local:Answer Value="1" Text="No" />
           <local:Answer Value="2" Text="Help Me Please" />
          </local:QuestionAndAnswers.Answers>
        </local:QuestionAndAnswers>
      </local:QuestionnaireControl.Questions>
    </local:QuestionnaireControl>
