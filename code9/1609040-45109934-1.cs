    **C# 6+**
        public DateTime DateCreated { get; set; } = DateTime.Now;
    **Previous C#**
        private DateTime? dateCreated;
        public DateTime DateCreated
        {
            get { return dateCreated ?? DateTime.Now }
            set { dateCreated = value; }
        }
    Lists and other complex types are a bit more difficult, since you only want to instantiate them if they are null. The C# 6 initializer syntax is the same here, but for previous versions of C#, you should use:
        private IEnumerable<Player> subs;
        public IEnumerable<Player> Subs
        {
            get
            {
                if (subs == null)
                {
                    subs = new List<Player>();
                }
                return subs;
            }
            set { subs = value; }
        }
