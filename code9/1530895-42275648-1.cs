    public interface IInsertInformationQuery : IExecuteQuery
    {
        string CodeId { get; set; }
        string SubInventoryCode { get; set; }
        string ContactCode { get; set; }
        string CompanyCode { get; set; }
        string CorgCode { get; set; }
        string UserCode { get; }
    }
