    public class StoreAnalyticOrdersComparer : IEqualityComparer<StoreAnalyticOrders>
    {
	    bool IEqualityComparer<StoreAnalyticOrders>.Equals(StoreAnalyticOrders s1, StoreAnalyticOrders s2)
	    {
		    return s1.OrderDate == s2.OrderDate;
   	    }
	    int IEqualityComparer<StoreAnalyticOrders>.GetHashCode(StoreAnalyticOrders obj)
	    {
		    if (Object.ReferenceEquals(obj, null))
			    return 0;
		    return obj.OrderDate.GetHashCode();
	    }
    }
