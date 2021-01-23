    public class EmailFormModel
    {      
      [AllowHtml]
      public string Message { set;get;}
      public string FromEmail {set;get;}
      //Other properties of view model goes here
    }
