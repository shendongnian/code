    public class MemberPopulator
    {
        private readonly SqlConnection connection;
        private const string MemberSql = @"
                INSERT INTO Members (FirstName, LastName, ReferralId, Active, Created) 
                VALUES (@FirstName, @LastName, @ReferralId, @Active, @Created);
                SELECT CAST(SCOPE_IDENTITY() as int)";
        private int TotalMemberCount;
        private const int MaxMemberCount = 200000;
        public MemberPopulator()
        {
            connection = new SqlConnection("Data Source=localhost;Initial Catalog=MyTestDb;Integrated Security=True");
        }
        public void CreateMembers()
        {
            //clear members
            connection.Execute("TRUNCATE TABLE Members");
            //create the 'original' member (top of pyramid)
            var originalMemberId = connection.Query<int>(MemberSql, new Member
            {
                FirstName = "FirstName Goes Here",
                ReferralId = 0
            }).Single();
            //now we have 1 total members
            TotalMemberCount = 1;
            //recursively create members, starting with original member,
            NonRecursiveCreate(originalMemberId);
        }
        private void NonRecursiveCreate(int root)
        {
            Queue<int> members = new Queue<int>();
            members.Enqueue(root);
            while (members.Any() && TotalMemberCount < MaxMemberCount)
            {
                var referralId = members.Dequeue();
                //Create 10 members
                var refs = CreateReferredMembers(referralId, 10);
                foreach (int i in refs)
                {
                    members.Enqueue(i);
                }
            }
        }
        private IEnumerable<int> CreateReferredMembers(int referralId, int numberOfReferrals)
        {
            var referredMemberIds = new List<int>();
            for (var i = 0; i < numberOfReferrals; i++)
            {
                if (TotalMemberCount >= MaxMemberCount)
                    break;
                var member = new Member
                {
                    FirstName = "FirstName Goes Here",
                    ReferralId = referralId
                };
                var memberId = connection.Query<int>(MemberSql, member).Single();
                referredMemberIds.Add(memberId);
                TotalMemberCount++;
            }
            return referredMemberIds;
        }
    }
