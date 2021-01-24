     [XmlArray("value")]
     public Value[] Items
     {
         get { return itemsField; }
         set { itemsField = value; }
     }
    
     [XmlType("Value")]
     public class Value
     {
        ....
     }
