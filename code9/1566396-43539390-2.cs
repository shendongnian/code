    public static class GetStringFromSomeProcess
    {
        private static readonly Lazy<string> _theAnswer = new Lazy<string>(GoGetTheAnswerFromALongRunningProcess);
        public static string GetString
        {
            get
            {
                return _theAnswer.Value;
            }
        }
        public static string GoGetTheAnswerFromALongRunningProcess()
        {
            return "X";
        }
    }
