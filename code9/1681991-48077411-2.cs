    public class PaginationReturn<T>
    {
        public PaginationReturn()
        {
            this._errors = new List<string>();
            this.Success = true;
        }
    
        public IEnumerable<T> Data { get; set; }
        public Boolean Success { get; private set; }
        private List<string> _errors;
    
        public IReadOnlyList<string> Errors
        {
            get
            {
                return _errors.AsReadOnly();
            }
        }
    
        public void AddError(String mensagem)
        {
            this._errors.Add(mensagem);
            this.Success = false;
        }
    }
