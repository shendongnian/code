    public List<CategoryNew> ConverModelToNew(List<CategoryModel> lstCatModel){
        List<CategoryNew> lstCatNew = new List<CategoryNew>();
        
        foreach(var item in lstCatModel){
            lstCatNew.Add(new CetagoryNew(item));
        }
        return lstCatNew;
    }
