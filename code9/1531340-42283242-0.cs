    public class Member
    {
        public Member(DataRow dataRow)
        {
            MemberID = Convert.ToInt32(dataRow["MemberID"]);
            MemberName = Convert.ToString(dataRow["MemberName"]);
        }
        public int MemberID { get; set; }
        public string MemberName { get; set; }
    }
