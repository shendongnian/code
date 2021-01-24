    [DataContract]
    public class ExamClass
    {
        string question;
        string answer1;
        string answer2;
        string answer3;
        string answer4;
        Int32 correct;
        [DataMember]
        public string Question
        {
            get
            {
                return question;
            }
    
            set
            {
                question = value;
            }
        }
    
        [DataMember]
        public string Answer1
        {
            get
            {
                return answer1;
            }
    
            set
            {
                answer1 = value;
            }
        }
    
        // ...
    }
