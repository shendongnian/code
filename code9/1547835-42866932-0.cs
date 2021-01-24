    public class SaveEmailModel{
        public string Email{get;set;}
    }
    
    public IHttpActionResult SaveEmailForDiscount([FromBody] SaveEmailModel model){
    ...
    }
