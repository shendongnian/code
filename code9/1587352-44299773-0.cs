      public class InnerList
        {
            public int Value
            {
                get
                {
                    return this.intList.Count;
                }
            }
            public bool HasValue { get; set; }
            private List<InnerList> intList;
            public static implicit operator string(InnerList list)
            {
                return list.ToString();
            }
            public override string ToString()
            {
                if (this.HasValue)
                {
                    return this.Value.ToString();
                }
                else
                {
                    return this.intList.ToString();
                }
            }
        }
