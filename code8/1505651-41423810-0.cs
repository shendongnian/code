    public class DataBase
    {
        public Items[] GetItems()
        {
            return Enumerable.Range(1,500).Select(o => new Items (o, "item" + o)).ToArray();     
        }
    }
