        public class PatRegDto
        {
            public string Action { get; set; }
            private Int64 _FileId;
            public Int64 FileId
            {
                get
                {
                    return this._FileId;
                }
                set
                {
                    this._FileId = value;
                }
            }
            public string FName { get; set; }
            public string MName { get; set; }
            public string LName { get; set; }
            public string fullname
            {
                get { return FName + " " + MName + " " + LName; }
            }
            public DateTime Dob { get; set; }
            public List<PatParDto> PartnerInfo { get; set; }
        }
        public class PatParDto
        {
            public string Action { get; set; }
            public long RecId { get; set; }
            public long FileId { get; set; }
            public long ParFileId { get; set; }
            public DateTime SDate { get; set; }
            public DateTime? EDate { get; set; }
            public DateTime dob { get; set; }
            public string FullName { get; set; }
        }
