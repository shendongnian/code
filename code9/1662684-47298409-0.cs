    public class ImmutableJObejct
    {
        private readonly JObject _jObject;
        public ImmutableJObejct(JObject jObject)
        {
            _jObject = jObject;
        }
        public JObject JObject
        {
            get { return new JObject(_jObject); }
        }
    }
