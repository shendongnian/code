    interface ICsv { }
    
    class CsvType1 : ICsv { }
    
    class CsvType2 : ICsv { }
    
    class Csvs<TCsvModel> 
       where TCsvModel: ICsv
    {
        public Csvs(IList<TCsvModel> csvModel)
        {
           this.Dockets = csvModel;
        }
    
        public IList<TCsvModel> Dockets { get; private set;}
    }
