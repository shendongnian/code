    [Schema]
    public class AdditionRequest
    {
        [Id(0)]
        public int X { get; set; }
        [Id(1)]
        public int Y { get; set; }
    }
    [Schema]
    public class AdditionResponse
    {
        [Id(0)]
        public int Output { get; set; }
    }
