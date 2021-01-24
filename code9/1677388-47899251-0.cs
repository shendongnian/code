    public int getUserId(string un, string pw)
        {
            int query;
            using (var context = new IngredientsLinqDataContext())
            {
                --change here
                query = (from c in context.USERs
                            where c.Username == un && c.Password == pw
                            select c.UserID).FirstOrDefault();
            }
            if(query != 0)       --change here
            {
                return query;//a very serious kludge. Need to fix this
            }
            else { return -1; }
    
        }
