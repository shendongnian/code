    class ClientNameEqualityComparer : IEqualityComparer<Box>
    {
        public bool Equals(Clients c1, Clients c2)
        {
            if (c2 == null && c1 == null)
               return true;
            else if (c1 == null | c2 == null)
               return false;
            else if(c1.Name == c2.Name)
                return true;
            else
                return false;
        }
    
        public int GetHashCode(Client c)
        {
            return c.Name.GetHashCode();
        }
    }
