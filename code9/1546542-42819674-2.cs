    public class IndexViewModel
    {
        public List<tblProducts> Product1List { get; set; }
        public List<tblProducts> Product2List { get; set; }
        public List<tblProducts> Product3List { get; set; }
        //etc...
        public IndexViewModel()
        {
            Product1List = new List<tblProducts>();
            Product2List = new List<tblProducts>();
            Product3List = new List<tblProducts>();
            //etc...
        }
    }
