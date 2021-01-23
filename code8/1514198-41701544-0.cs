       public class Item
        {
            public int ItemId {get;set;}
            public int? ParentId => Parent?.ItemId;
            public string Column1 {get;set;}
            public string Column2 {get;set;}
            public Item Parent {get;set;}
        }
