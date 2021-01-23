    // let's assume we would like to have each ObjectModel with
    // unique Name and Class properties
    // this two data will identify the whole row. (i.e ShadowHawk:Bow)
    class ObjectModel {
       
       public string Name { get; set; }
       public ItemClass ItemClass { get; set; }
       ...
       public MagicAttr[] Attributes { get; set; }
       ...
    }
    
    class ObjectEntity : ObjectModel {
       
       public int Class_id
       ...
       other foreign keys as primary keys
    }
