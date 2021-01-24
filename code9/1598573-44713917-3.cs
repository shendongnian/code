        public List<Address> GetAddresses(string UserName)
        {
            var addresses = db.Customers.Where(p=> p.UserName == UserName).SelectMany(a=> a.Addresses).ToList();
        
            return addresses;
        }
