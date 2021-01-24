        using (var context = new IngredientsLinqDataContext())
        {
            query = from c in context.USERs
                where c.Username == un && c.Password == pw
                select c.UserID;
            if (query.Count() >= 1)
            {
                return query.Min();//a very serious kludge. Need to fix this
            }
            else { return -1; }
        }
