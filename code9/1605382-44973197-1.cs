        class CollectionObject
        {
            public int PersonID { get; set; }
            public int? CategoryID { get; set; }
            public int? SubcategoryID { get; set; }
       
        public static List<CollectionObject> GetListCollectionObj()
        {
            List<CollectionObject> LColObj = new List<CollectionObject>();
            LColObj.Add(new CollectionObject() { PersonID = 61, CategoryID = 47, SubcategoryID = null });
            LColObj.Add(new CollectionObject() { PersonID = 61, CategoryID = 48, SubcategoryID = null });
            LColObj.Add(new CollectionObject() { PersonID = 61, CategoryID = 0, SubcategoryID = 424 });
            LColObj.Add(new CollectionObject() { PersonID = 61, CategoryID = 0, SubcategoryID = 425 });
            LColObj.Add(new CollectionObject() { PersonID = 101, CategoryID = 48, SubcategoryID = null });
            LColObj.Add(new CollectionObject() { PersonID = 101, CategoryID = null, SubcategoryID = 424 });
            LColObj.Add(new CollectionObject() { PersonID = 666, CategoryID = 47, SubcategoryID = null });
            LColObj.Add(new CollectionObject() { PersonID = 666, CategoryID = null, SubcategoryID = 424 });            
            return LColObj;
        }
    }
