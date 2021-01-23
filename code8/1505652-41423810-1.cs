    public class DataBase
    {
        public Items[] GetItems()
        {
            return Enumerable.Range(1,500).Select(o => new Items ((uint)o, "item" + o)).ToArray();     
        }
    }
