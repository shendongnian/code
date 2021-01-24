    public class ModelStateDictionary : IDictionary<string, ModelState>
    {
        private readonly IDictionary<string, ModelState> _innerDictionary;
        public ICollection<ModelState> Values
        {
            get { return _innerDictionary.Values; }
        }
        public bool IsValid
        {
            get { return Values.All(modelState => modelState.Errors.Count == 0); 
        }
    }
