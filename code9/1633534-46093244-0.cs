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
        public string Dob { get; set; }
        public List<PatParDto> PartnerData { get; set; }
    }
