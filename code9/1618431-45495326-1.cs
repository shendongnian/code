        public MyType Update(MyType obj) {
            ...
            var oFilter = Builders<MyType>.Filter.Eq(o => o.MyId, obj.MyId);
            var oResult = oCollection.UpdateMany(
                                     { o.MyId: obj.MyId },
                                     { $set: { "MyFieldName" : MyValue} }
    
                                                 );
            if(oResult!=null)
                Console.Writeline("object to update found");
            ...
            return oResult;
        }
