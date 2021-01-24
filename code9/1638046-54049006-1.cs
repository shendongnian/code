    public virtual IEnumerable<GetProductCategoryList_Result> GetProductCategoryList(Nullable<int> userID)
    {
        var userIDParameter = userID.HasValue ?
            new SqlParameter("UserID", userID) :
            new SqlParameter("UserID", System.Data.SqlDbType.Int);
    
        //return this.Database.SqlQuery<GetProductCategoryList_Result>("GetProductCategoryList @UserID", userIDParameter).ToList();
        return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<GetProductCategoryList_Result>("osa.GetProductCategoryList @UserID", userIDParameter);
    }
