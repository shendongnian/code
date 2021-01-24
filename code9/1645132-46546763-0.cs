    class Question
    {
        [ScriptIgnore]
        public int QID { get; set; }
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public IList<Answer> Answers { get; private set; }
        public Question()
        {
            Answers = new List<Answer>();
        }
        public Question( int questionID, string questionText, IList<Answer> answers )
        {
            Answers = answers;
            QuestionID = questionID;
            QuestionText = questionText;
        }
        public string ToWeirdString()
        {
            string sout = $"\tquestion id={QuestionID}\n" +
                            $"\tQuestion =\"{QuestionText}\"\n";
            sout += "\t{\n";
            foreach (var i in Answers)
            {
                sout += $"\t\tANSWER=\"{i.AnswerText}\";\n";
            }
            sout += "\t}\n";
            return sout;
        }
    }
    
    class Answer
    {
        public Answer(string answerText, int answerType)
        {
            AnswerText = answerText;
            AnswerType = answerType;
        }
        public string AnswerText { get; set; }
        [ScriptIgnore]
        public int AnswerType { get; set; }
    }
