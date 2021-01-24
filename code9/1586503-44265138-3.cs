    public class MyRecord 
    { 
        public int ID{get;set;}
        public DateTime Date {get;set;}
        public decimal Value {get;set;}
        public MyRecord(int id,DateTime date,decimal value){....}
    }
   ...
    var myValues=new List<MyRecord>
                 {
                     new MyRecord(1,new DateTime(2017,6,15),64.73m),
                     new MyRecord(1,new DateTime(2017,6,15),1.39m)
                 };
    var myTable=myValues.ToDataTable();
