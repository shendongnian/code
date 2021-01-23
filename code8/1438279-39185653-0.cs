        public class MaxPQ<T> : IComparable<MaxPQ<T>>
        {
            static SortedDictionary<T, MaxPQ<T>> dict = new SortedDictionary<T, MaxPQ<T>>();
            private string pq;
            private int N;
            private void exch(T i, T j)
            {
                MaxPQ<T> temp = dict[i];
                dict[i] = dict[j];
                dict[j] = temp;
            }
            public int CompareTo(MaxPQ<T> obj) //Required type arguments
            {
                int results = 0;
                if (this.pq == obj.pq)
                {
                    results = this.N.CompareTo(obj.N);
                }
                else
                {
                    this.pq.CompareTo(obj.pq);
                }
                return results;
            }
     
        }
