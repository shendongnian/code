        public class MemberData : IComparable<MemberData>
        {
            public static List<MemberData> memberData = new List<MemberData>();
            public string givenName {get;set;}
            public string surName {get;set;}
            public string memberID { get;set;}
            public string memberPoint { get; set; }
            public void displayAllMembers()
            {
                int index = 1;
                Console.WriteLine("ALL MEMBERS");
                Console.WriteLine("No\t Member Name\t\t Member ID\t Member Point");
                memberData.Sort();
                foreach (MemberData data in memberData)
                {
                    Console.WriteLine("{0}\t\t {1} {2}\t\t {3}\t\t {4}", index, data.givenName, data.surName, data.memberID, data.memberPoint);
                    index++;
                }
            }
            public int CompareTo(MemberData other)
            {
                if (this.givenName != other.givenName) return this.givenName.CompareTo(other.givenName);
                if (this.surName != other.surName) return this.surName.CompareTo(other.surName);
                if (this.memberID != other.memberID) return this.memberID.CompareTo(other.memberID);
                return this.memberPoint.CompareTo(other.memberPoint);
            }
        }
