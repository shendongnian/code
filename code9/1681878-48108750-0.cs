        public override int Id
        {
            get { return (UserId.ToString() + LoginProvider + ProviderKey).GetHashCode(); }
            set { Id = (UserId.ToString() + LoginProvider + ProviderKey).GetHashCode(); }
        }
