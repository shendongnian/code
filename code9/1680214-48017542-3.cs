    public virtual IList<usp_GetFileType_Result> GetCustOrderHist()
            {
                IList<usp_GetFileType_Result> data = ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<usp_GetFileType_Result>("CALL usp_GetFileType();").ToList();
    
                return data;
            }
    
