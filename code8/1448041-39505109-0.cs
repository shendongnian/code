    var qi1 = (from qi in quoteItems orderby qi.price1 select new {qi.QuoteItem_InquiryItem}).AsEnumerable().Select((i, index) => new {i.QuoteItem_InquiryItem, Rank = index + 1});
    
    var qi2 = (from qi in quoteItems orderby qi.price2 select new {qi.QuoteItem_InquiryItem}).AsEnumerable().Select((i, index) => new {i.QuoteItem_InquiryItem, Rank = index + 1});
    
    var qi3 = (from qi in quoteItems orderby qi.price3 select new {qi.QuoteItem_InquiryItem}).AsEnumerable().Select((i, index) => new {i.QuoteItem_InquiryItem, Rank = index + 1});
    
    
    return colQuoteItem = from vQuote in this.vQuoteItemOverviews.AsEnumerable()
        where vQuote.IdConstructionStageId == ConstructionStageId                               
        group vQuote by new
        {
            vQuote.IdAccount
        } into g                                                              
        select new vQuoteItemOverviewSum
        {
            Id = g.Max(x => x.Id),                                   
            Price1Order = qi1.FirstOrDefault(_ => _.IdConstructionStageId == x.Id)?.Rank,  //Here i need the ROW_NUMBER like in the SQL-Syntax
            Price2Order = qi2.FirstOrDefault(_ => _.IdConstructionStageId == x.Id)?.Rank,  //Here i need the ROW_NUMBER like in the SQL-Syntax
            Price3Order = qi3.FirstOrDefault(_ => _.IdConstructionStageId == x.Id)?.Rank,  //Here i need the ROW_NUMBER like in the SQL-Syntax
            price1 = g.Sum(x => x.price1),
            price2 = g.Sum(x => x.price2),
            price3 = g.Sum(x => x.price3),                                   
        }
        ;
