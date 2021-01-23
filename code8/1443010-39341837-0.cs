    public class DocumentListViewModel
    {
        private IQueryable<Document> _Documents;
        public  IQueryable<Document> Documents 
       { 
         get 
         { 
            return _Documents.Ordery(x=>x.Id);
         } 
         set 
         { 
            _Documnets = value;
         } 
       }
    }
