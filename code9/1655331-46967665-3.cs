    // create enum - how to pad
    public enum PadStyle    
    {
        Right
        Left
    }
    // create attribute class
    public class PaddingAttribute : Attribute
    {
         public int TotalLen {get;set;}
         public PadStyle Style {get;set;}
         public char PadChar {get;set;}
         public int Order {get;set;}
    }
    // Create class record base - this one knows how to get properties, read attributes and pad values into one string
    public class RecordBase
    {
         protected string CreateRecordProtected()
         {
             // here you 
             // 1 - use reflection to get properties
             // 2 - use reflection to read PaddingAttribute from properties
             // 3 - pad property values using data in PaddingAttribute
             // 4 - concatenate record 
             // something like
             var result = o.GetPropeties().Where(...).Select(...padding logic...);
             return string.Join("", result);
             // padding logic = string.PadRight or string.PadLeft
         }
    }
