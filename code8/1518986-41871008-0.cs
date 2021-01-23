    Class MySetOfDataBlock
    {
        private List<MyDataBlock> _DataSet;
           = new List<MyDataBlock>();
        public IList<MyDataBlock> DataSet{
            get{
               return _DataSet.AsReadOnly();
            }
        }
        bool SomeParam;
        Double lots of other params;
    }
