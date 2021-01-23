    public interface IDataUnitModel{}
    public class StringDataUnitModel : IDataUnitModel
    {
      public string Value {get;set;}
    }
    public class ImageDataUnitModel : IDataUnitModel
    {
      public Image Value {get;set;}
    }
    //...
    public List<IDataUnitModel> list = new List<IDataUnitModel>();
    list.Add(new StringDataUnitModel{Value = "ABC"});
    list.Add(new ImageDataUnitModel());
