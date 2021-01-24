    public class Const
    {
        public const string Provider = "Microsoft.VisualStudio.TestTools.DataSource.CSV";
        public const string ConnString = "|DataDirectory|\\stores.csv";
        public const string Table = "stores#csv";
        public const string Method = DataAccessMethod.Sequential;
    }
    [DataSource(Const.Provider, Const.ConnString , Const.Table , Const.Method)]
