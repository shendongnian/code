    public class AddOfferViewModel
    {
       public AddOfferAnnounceModel Model {get;set;}
       public SelectList AnnouncementTypeSelectList {get;set;}
       public AddOfferViewModel()
       {
           Model = new AddOfferAnnounceModel();
       }
    }
