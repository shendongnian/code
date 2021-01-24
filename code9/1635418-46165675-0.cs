    public partial class MyModel : DbContext
        {
        public MyModel()
                    : base("name=MyModelDataContext") // <-- ConnString Name
                {
                }
    }
