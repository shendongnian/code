    public MyType Update(MyType obj) {
        ...
        var oFilter = Builders<MyType>.Filter.Eq(o => o.MyId, obj.MyId);
        var oResult = oCollection.UpdateMany(oFilter, obj);
        if(oResult!=null)
            Console.Writeline("object to update found");
        ...
        return oResult;
    }
