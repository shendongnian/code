    IMongoFields fields = Fields.Include("_id", "name", "thumbnail").ElemMatch("memberinfo", 
            Query.And(
                Query.EQ("status", "approved"),
                Query.GTE("height", 160),
                Query.LTE("height", 170),
                Query.GTE("weight", 55),
                Query.LTE("weight", 65),
                Query.And(Query.Or(andList)))
     );
