    public class MyBook : IBook{
      
       public Title : {get;set;} = "MyBook";
       public func<int,string> ReadPage =(pagenumber)=>{
           return GetText(pagenumber);
       }  
       public string GetText(int pageNumber){
          //read the page text by number here.
       }
    }
