        public Team()
            : this(null, null)
        {
        }
        public Team(String teamName, String userId) 
        {
            Name = teamName;
            TransfersRemaining = 5;
            Owner = userId;
            StartingXI = Enumerable.Empty<Player>();
            Subs = Enumerable.Empty<Player>();
            DateCreated = DateTime.Now;
        }
