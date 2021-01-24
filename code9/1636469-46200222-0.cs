        public void IncreaseAge(IQueryable<Human> humans) 
        {            
            foreach( var h in humans)
            {
                h.Age++;
            }
            SaveChanges();
        }
