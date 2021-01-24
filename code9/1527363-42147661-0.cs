    public class UserInfo
    {
        public string DisplayName { get; set; }
        //include anything else you may need.
    }
    var timequery = from t in TimeRecords
                    select new UserInfo
                    {
                     DisplayName = t.User.DisplayName
                     };
