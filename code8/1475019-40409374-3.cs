    class AnswersCollection : IEnumerable<Answer>
    {
        public List<Answer> answers { get; set; }
        public IEnumerator<Answer> GetEnumerator()
        {
            return answers != null ? answers.GetEnumerator() : new List<Answer>().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
