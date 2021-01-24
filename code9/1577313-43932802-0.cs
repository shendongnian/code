    public class Form
    {
        private ICollection<FormAndQuestionMapping> _formQuestionMappings;
        public Form()
        {
            _formQuestionMappings = new SortedSet<FormAndQuestionMapping>(new Comparer());
        }
        private class Comparer : IComparer<FormAndQuestionMapping>
        {
            public int Compare(FormAndQuestionMapping x, FormAndQuestionMapping y)
            {
                return x.SortOrder - y.SortOrder;
            }
        }
        [key]
        int FormID { get; set; }
        int Name { get; set; }
        public virtual ICollection<FormAndQuestionMapping> FormQuestionMappings
        {
            get { return _formQuestionMappings; }
            set { _formQuestionMappings = value; }
        }
    }
    public class FormAndQuestionMapping
    {
        [ForeginKey]
        int FormID { get; set; }
        [ForeginKey]
        int QuestionID { get; set; }
        public int SortOrder { get; set; }
        public virtual Form Form { get; set; }
        public virtual Question Question { get; set; }
    }
