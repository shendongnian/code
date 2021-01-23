    public class ListCode : List<int>
    {
        public ListCode(string code)
        {
            Code = code;
        }
        public string Code { get; set; }
    }
    ListCode myList = new ListCode("bar") { 1, 2, 3};
