    public class MyProfViewModel
    {
        public int myprofID { get; set; }
        public string myprofDes { get; set; }
        public static MyProfViewModel FromModel(PROF model)
        {
            var viewModel = new MyProfViewModel()
            {
                myprofID = model.ID,
                myprofDes = model.DESCRIPTION
            };
            return viewModel;
        }
    }
