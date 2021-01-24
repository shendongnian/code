    public enum TemplateType
    {TextBox,ColorPicker};
    public class TabloidBaseControl
    {
      public virtual DbType DefaultFieldType
      {
        get { return DbType.String; }
      }
      public virtual int? DefaultFieldLength
      {
        get { return 20; }
      }
      public virtual int? DefaultFieldDecimal
      {
        get { return null; }
      }
    }
    
    public class TCColorPicker : TabloidBaseControl
    {
      public override int? DefaultFieldLength
      {
        get { return 7; }
      }
    }
    
    public class TCTextBox : TabloidBaseControl
    {
      public override int? DefaultFieldLength
      {
        get { return 20; }
      }
    }
