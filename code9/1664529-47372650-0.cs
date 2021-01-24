    public class EndComparer : IComparer<Lines>
    {
    	public int Compare(Lines _lineX, Lines _lineY)
    	{
    		return _lineX._End.CompareTo(_lineY._End);
    	}
    }
