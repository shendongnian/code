    List<CategoryNew> lstCatNew = new List<CategoryNew>();
    List<CategoryModel> lstCatModel = new List<CategoryModel>();
    // populate list with CategoryModel objects
    foreach(var item in lstCatModel){
        lstCatNew.Add(new CetagoryNew(item));
    }
