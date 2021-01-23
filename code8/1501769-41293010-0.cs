            public class DataTestPlanComparer : IEqualityComparer<DataTestPlan>
            {
                public bool Equals(DataTestPlan x, DataTestPlan y)
                {
    
                    if (Object.ReferenceEquals(x, y)) return true;
    
                    if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                        return false;
    
                    return x.DataID == y.DataID && x.ProductID == y.ProductID;
                }
    
    
                public int GetHashCode(DataTestPlan dataTestPlan)
                {
                    if (Object.ReferenceEquals(dataTestPlan, null)) return 0;
    
                    int hashDataTestPlanDataID = dataTestPlan.DataID == null ? 0 : dataTestPlan.DataID.GetHashCode();
    
                    int hashDataTestPlanProductID = dataTestPlan.ProductID.GetHashCode();
    
                    return hashDataTestPlanDataID ^ hashDataTestPlanProductID;
                }
            }
