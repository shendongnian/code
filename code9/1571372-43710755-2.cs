    public class TimePeriodEqualityComparer : IEqualityComparer<TimePeriod>
    {
	  public bool Equals(TimePeriod a, TimePeriod b)
	  {
		if (object.ReferenceEquals(a, b)) {
			return true;
		}
		if (a.Start < b.Start && a.End > b.End) {
			return true;
		}
		if ((a.Start < b.Start && a.End > b.Start) || (a.Start < b.End && a.End > b.End)) {
			return true;
		}
		
		return false;
	  }
	
	  public int GetHashCode(TimePeriod o)
	  {
		// we have to force using the Equals method as it is only used to
        // break the tie when two objects have the same HashCode
		return 0;
	  }
    }
