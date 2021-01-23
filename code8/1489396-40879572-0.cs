    public class member
        {
            int Num;
            private readonly List<member> _parrentList;
    
            public member(List<member> parrentList)
            {
                _parrentList = parrentList;
            }
    
            public int IndexOnParentList => _parrentList.IndexOf(this);
        }
