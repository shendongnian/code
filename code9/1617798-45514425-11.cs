    public class MyObj : IAllowedParamType
    {
        public int Id { get; set; }
        public MyObj(int id)
        {
            Id = id;
        }
    }
