    public class myemailModel {
       public string Username{get;set;}
       public IList<Data> data{get;set;}
       public class Data{
          public string Name{get;set;}
          public int Age{get;set;}
       }
    }
