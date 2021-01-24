    // enumerate any number of lists and return an object[] for each index
    public class MultiListIterator: IEnumerator<object[]>, IEnumerable<object[]>, IEnumerable
    {
        readonly List<IEnumerator> lists = new List<IEnumerator>();
        public MultiListIterator(params IEnumerable[] lst)
        {
           Array.ForEach(lst , (item) => lists.Add(item.GetEnumerator()));
        }
       
        IEnumerator IEnumerable.GetEnumerator()
        {
           return this;
        }
    
        // generic enumerator
        public IEnumerator<object[]> GetEnumerator()
        {
           return this;
        }
        
        public bool MoveNext()
        {
            bool any = false;
            // keep track of which are completed
            var completed = new List<IEnumerator>();
            foreach(var list in lists)
            {
                if (list != null) 
                {
                    var move = list.MoveNext();
                    any = any || move;
                    if (!move) completed.Add(list);
                }
            }
            // nullify the completed iterators
            foreach(var nullitem in completed)
            {
                lists[lists.IndexOf(nullitem)] = null;
            }
            return any;
        }
        
        object IEnumerator.Current 
        {
            get 
            {
                return Current;
            }
        }
        
        // generic Enumerator
        public object[] Current 
        {
            get 
            {
                object[] result = new object[lists.Count];
                for(int i=0; i<lists.Count; i++) 
                {
                    if (lists[i] != null)
                    {
                        result[i] = lists[i].Current;
                    } 
                }
                return result;
            }
        }
        
        public void Reset() 
        {
        }
        public void Dispose() 
        {
        }  
    }
