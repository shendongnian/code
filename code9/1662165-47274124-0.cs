    [TestMethod()]
    public void CreateManifestFilters_FunctionHitWithCIDPopulated_ExpressionFiltersOnCID()
    {
        var filterItem = new ManifestFilterItem("002");
        var predicate = _iManifestManager.CreateManifestFilters(filterItem);
        var predicateFunc = predicate.Compile();
        var manifest1 = new uv_Manifest{ CID = "001" };
        var manifest2 = new uv_Manifest{ CID = "002" };
    
        var result1 = predicateFunc(manifest1);
        var result2 = predicateFunc(manifest2);
    
        Assert.IsFalse(result1);
        Assert.IsTrue(result2);
    }
