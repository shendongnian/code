    public class ColumnWeight : Attribute
        {
            public int Weight { get; set; }
            public ColumnWeight(int weight)
            {
                Weight = weight;
            }
    }
