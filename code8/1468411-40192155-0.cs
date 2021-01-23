    public static Expression<Func<User, bool>> Test
    {
        get
        {
            //Use one expression inside another via Invoke
            Expression<Func<User, bool>> res = (u => GetAbilities.Invoke(u).Any());
            return res.Expand(); //Expand to create a full expression
            //The result would be the same as if you have used
            //u => u.AllAbilities.Where(a => a.Type == Ability.TypeE.Initial).Any()
        }
    }
