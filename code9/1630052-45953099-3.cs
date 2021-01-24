    class Farmer
    {
        public Farmer(IUser user)
        {
            this.Name = user.Name;
            ...
            // also set the members that exist only on farmer
        }
    }
