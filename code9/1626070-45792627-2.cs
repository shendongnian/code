    public class Document
    {
        public List<DocumentObj> document { get; set; }
    }
    DocumentQueryObject documents = new DocumentQueryObject()
    {
        documents = new[] 
        {
            new Document()
            {
                document =
                    obj.Select(s => new DocumentObj()
                    {
                        doctype = s.doctype
    
                    }).ToList()
            }
        }
    
    };
