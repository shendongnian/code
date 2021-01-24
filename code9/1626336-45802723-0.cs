    [HttpPost]
    [ResponseType(typeof(List<ValueStory>))]
    public IHttpActionResult UserValueStories ([FromBody] ValueStory valuestory) {
        if (valuestory.Id == "" || valuestory.Id == null) {
           //what code to add to change status code to 400 and to display error message?
           return BadRequest("error message");
        }    
    
        var valueStoryName = (from vs in db.ValueStories
                              where vs.Id == valuestory.Id
                              select vs).ToList();    
    
        var vs1 = new List<ValueStory>();
        foreach (var v in valueStoryName) {
            vs1.Add(new ValueStory() {
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
        return Ok(vs1);    
    }
