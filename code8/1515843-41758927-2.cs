    public class MyDataType
    {
         public string AnyThingOfInterest
         {
             get; set;
         }
         public static MyDataType FromKeyEventArgs(KeyEventArgs e)
         {
             return new MyDataType() { AnyThingOfInterest = e.ToString() };
         }
         public static MyDataType FromMouseEventArgs(MouseEventArgs e)
         {
             return new MyDataType() { AnyThingOfInterest = e.ToString() };
         }
    }
