    // POST: api/ValueStories
    public async Task<IHttpActionResult> PostValueStory(AbcViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        //Manual map or use Automapper here
        var entity = Mapper.Map<ValueStory>(viewModel);
        db.ValueStories.Add(entity);
        //db.BusinessValueToYou.AddRange(entity.BusinessValueToYou); // can map with automapper
    
        await db.SaveChangesAsync();
    
        return CreatedAtRoute("DefaultApi", new { id = entity .Id }, entity );
    }
    
    public class AbcViewModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string ValueStoryName { get; set; }
        public string Organization { get; set; }
        public string Industry { get; set; }
        public string Location { get; set; }
        public string AnnualRevenue { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public IEnumerable<BusinessValueToYouViewModel> BusinessValueToYou { get; set; }
    }
    public class BusinessValueToYouViewModel
    {
        public int Id { get; set; }
        public int BVUSId { get; set; }
        public int BalanceSheet { get; set; }
        public int IncomeStatement { get; set; }
        public IEnumerable<ValueDriverViewModel> ValueDriver { get; set; }
    }
    public class ValueDriverViewModel
    {
        public int Id { get; set; }
        public int BVUSId { get; set; }
        public int BVUId { get; set; }
        public string ValueDriver { get; set; }
        public bool Selected { get; set; }
        public int TotalSavings { get; set; }
    }
