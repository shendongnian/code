    public void SetTypeOnCList(List<D> dlist, List<C> clist)
    {
        clist.ForEach(c =>
        {
            var dobj = dlist.FirstOrDefault(d => d.CIds.Contains(c.Id));
            if (dobj != null)
            {
                c.Type = dobj.Type;
            }
        });
    }
