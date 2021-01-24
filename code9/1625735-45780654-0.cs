    // POST api/UserValueStories
    [ResponseType(typeof(ValueStory))]
    [Route("api/UserValueStories")]
    [HttpPost]
    public List<ValueStory> UserValueStories([FromBody] ValueStory valuestory)
    //public void UserValueStories([FromBody] ValueStory Id)
    {
        var valueStoryName = (from vs in db.ValueStories
                              where vs.Id == valuestory.Id
                              select vs).ToList();
        List<ValueStory> vs1 = new List<ValueStory>();
        foreach (var v in valueStoryName)
        {
            vs1.Add(new ValueStory()
            {
                Id = v.Id,
                ValueStoryName = v.ValueStoryName,
                Organization = v.Organization,
                Industry = v.Industry,
                Location = v.Location,
                AnnualRevenue = v.AnnualRevenue,
                CreatedDate = v.CreatedDate,
                ModifiedDate = v.ModifiedDate,
                MutualActionPlan = v.MutualActionPlan,
                Currency = v.Currency,
                VSId = v.VSId
            });
        }
        return vs1.ToList();
    }
