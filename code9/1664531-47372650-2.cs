    public class EndComparer : IComparer<Lines>
    {
    	public int Compare(Lines lineX, Lines lineY)
    	{
    		return lineX.End.CompareTo(lineY.End);
    	}
    }
