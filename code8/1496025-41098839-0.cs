public class ItemAttribute
{
    public int Value { get; set; }
}
public class Weapon
{
     private readonly ItemAttribute _strengthAttribute = new ItemAttribute();
     // ....
     
     private readonly ItemAttribute[] _attributes = new[] {_strengthAtribute};
     public int Strength
     {
         get { return _strengthAttribute.Value; }
         set { _strengthAttribute.Value = value; }
     }
}
