    class DataModels
    {
        public IEnumerable<string> ReturnDataFromTableX()
        {
            return _DataEntities.<TABLE_NAME>.Select(x => x.<COLUMN_NAME>);
        }
    }
