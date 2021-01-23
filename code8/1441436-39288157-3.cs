    public class PassItem 
    {
       public int? clientId { get; set; }
       public string uploadidList { get; set; }
       public int? currentFilter { get; set; }
       public int? page { get; set; }
    }
    
    public PartialViewResult batchSave(PassItem passItem)
    {
        if(passItem.page != null)
        {
            passItem.page--;
        } 
    }
