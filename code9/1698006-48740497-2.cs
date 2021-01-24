    public class AnyDataSource
    {
        //public List<AnyClass> List { get; set; }
        public List<AnyClass> LoadData()
        {
            //Load data from data source
            List<AnyClass> list = new List<AnyClass>();
            list.Add(new AnyClass { ColumnA = 3 });
            list.Add(new AnyClass { ColumnA = 1 });
            list.Add(new AnyClass { ColumnA = 6 });
            //Get the first value
            int valueToCompare = list[0].ColumnA;
            //Set the ValueToCompare property of every row with this first value
            foreach (var item in list)
            {
                item.ValueToCompare = valueToCompare;
            }
            return list;
        }
    }
