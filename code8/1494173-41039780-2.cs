     public class MyMembershipProvider : MembershipProvider
    { UserDb ObjDb;
      UserBs objbs;
    public MyMembershipProvider()
        {
            ObjDb = new UserDb();
            objbs = new UserBs();
        }
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }
     }
