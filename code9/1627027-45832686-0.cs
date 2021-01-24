    public class SurveyBase
    {
        public int Id { get; set; }
        public string SomeUrl { get; set; }
        public string TypeId { get; set; }
        //...
    }
    public class Survey1 : SurveyBase
    {
        public string MyQuestion1 { get; set; }
        public string MyQuestion2 { get; set; }
        //..
    }
    public class Survey2 : SurveyBase
    {
        public string OtherProperty { get; set; }
        public int Whatever { get; set; }
        //..
    }
