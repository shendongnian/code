    public void FillCollection<TItem>(List<TItem> supportList)
        where TITem : ICurrencyBankOrAmount
    {
        this.CollectionSupport.AddRange(
            supportList
                .Select( item => new SupportModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code,
                    YesNo = item.Id == this.CurrentId ? "yes" : "no"
                } )
        )
    }
