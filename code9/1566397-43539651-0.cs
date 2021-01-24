    public class GetStringFromSomeProcess
    {
        private string _theAnswer;
        public string theAnswer
        {
            get
            {
                if(theAnswer == null)
                {
                    GoGetTheAnswerFromALongRunningProcess getAnswer = new GoGetTheAnswerFromALongRunningProcess();
                    _theAnswer = getAnswer.GetAnswer();
                }
                return _theAnswer;
            }
        }
    }
