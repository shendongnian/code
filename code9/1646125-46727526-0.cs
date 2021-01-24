    class Table: IEnumerable
    {
        public Row a;
        public Row b;
        public Row c;
    
        public Table(Row _a, Row _b, Row _c)
        {
            a = _a;
            b = _b;
            c = _c;
    
        }
    
        public IEnumerator GetEnumerator()
        {
            yield return a;
            yield return b;
            yield return c;
        }
    }
 
    public class Row { }
