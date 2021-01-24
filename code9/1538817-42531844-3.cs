     public class BaseModel
        {
            //Common Properties here.
            public virtual void PopulateData(DataTable data)
            {
                //Override
            }
        }
        
        public class Model1 : BaseModel
        {
            //Model 1 Properties here.
            public string Name { get; set; }
    
            public override void PopulateData(DataTable data)
            {
                //Set all model values here from datatable.
        
            }
        }
        
  
     public class ModelFactory
        {
            private BaseModel _model;
        
            public BaseModel ReturnModelByName(string modelName, DataTable dtProductCatalog)
            {
                switch (modelName)
                {
                    case "Model1":
                        _model = new Model1();
                        _model.PopulateData(dtProductCatalog);
                        break;
        
                    case "Model2": //etc....
                        break;
                }
        
                return _model;
            }
        }
