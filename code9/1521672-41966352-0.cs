    public IEnumerable<IGrouping<Guid, PoolDownload>> Manuals
    {
        get
        {
            LookupField cat = (LookupField)this.Item.Fields["Category"];
    
            return this.Downloads.Where(i =>
                i.Item.TemplateID == PoolDownload.TemplateId
                && i.Item.GlassCast<Pdp.Pool.Website.Business.Entities.PoolDownload>().Category.ToString() == cat.TargetID.Guid.ToString())
                .GroupBy(i => i.Category);
        }
    }
