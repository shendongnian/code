    // Create class record - this one corresponds to your DB
    public class Record : RecordBase
    {
         private const string _fn_FiedName = "firstName";
         private const string _ln_FiedName = "lastName";
         public Record(IDataReader r)
         {
             FirstName = r[_fn_FiedName];
             LastName = r[_ln_FiedName];
         }
         [Padding(TotalLen = 15, Style = PadStyle.Right, PadChar = " ",  Order = 1)]
         public string FirstName{get;set;}
         [Padding(TotalLen = 20, Style = PadStyle.Right, PadChar = " ",  Order = 2)]
         public string LastName {get;set;}
         public override string ToString()
         {
             return base.CreateRecordProtected();
         }
