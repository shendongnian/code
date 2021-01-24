    public class BaseModel
        {
            //Common Properties here.
        }
    
        public class ColumnAModel : BaseModel
        {
            //Col A Properties here.
            public string Name { get; set; }
        }
    
        public class ModelFactory
        {
            private BaseModel _model;
    
            public BaseModel ReturnModelForColumn(string columnName, DataTable dtProductCatalog)
            {
                switch (columnName)
                {
                    case "ColumnA":
                        _model = new ColumnAModel();
                        //Populate Data from dtProductCatalog
                        break;
    
                    case "ColumnB": //etc....
                        break;
                }
    
                return _model;
            }
        }
